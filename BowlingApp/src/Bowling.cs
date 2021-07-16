using System;
using System.Linq;
using BowlingApp.Enums;
using BowlingApp.Models;
using Common.Validation;
using System.Collections.Generic;
using BowlingApp.Resources;

namespace BowlingApp.Src
{
    public class Bowling : IBowling
    {
        public List<Player> Players { get; private set; }

        private readonly IBowlingDataParser _textFileParser;

        public Bowling()
        {
            Players = new List<Player>();
            _textFileParser = new BowlingTextFileParser();
        }

        public Result LoadGame(string textFile)
        {
            var result = new Result();

            var parseResult = _textFileParser.Parse(textFile);

            if (parseResult.IsValid)
            {
                foreach (var playerResult in parseResult.Model)
                {
                    if (playerResult.IsValid)
                    {
                        Players.Add(playerResult.Model);
                    }
                    else
                    {
                        Console.WriteLine(string.Format(BowlingResources.NoResultsForPlayerError, playerResult.Model.Name, playerResult.ErrorMessage));
                    }
                }
            }
            else
            {
                result.AddError(parseResult.ErrorMessage);
            }

            return result;
        }

        public Result<int> CalculatePoints(List<Frame> frames)
        {
            var result = new Result<int>();

            if (frames != null && frames.Any() && frames.Count <= 10)
            {
                var framesValid = true;

                foreach (var frame in frames)
                {
                    var validationResult = frame.Validate();
                    framesValid = framesValid && validationResult;
                }

                if (framesValid)
                {
                    result.Model = CalculateFinalPoints(frames);
                }
                else
                {
                    result.AddError(BowlingResources.FramesNotValidError);
                }
            }
            else
            {
                result.AddError(BowlingResources.FramesCountError);
            }

            return result;
        }

        private int CalculateFinalPoints(List<Frame> frames)
        {
            var sum = 0;

            var index = 0;
            do
            {
                var round = index + 1;
                var elementsAhead = frames.Count - round;

                if (round < 10)
                {
                    if (frames[index].State == FrameState.Strike)
                    {
                        if (round < frames.Count)
                        {
                            if (frames[index + 1].State == FrameState.Strike && elementsAhead >= 2)
                            {
                                sum += frames[index].FirstRoll + frames[index + 1].FirstRoll + frames[index + 2].FirstRoll;
                            }

                            if (frames[index + 1].State != FrameState.Strike && frames[index + 1].State != FrameState.Unfinished && elementsAhead >= 1)
                            {
                                sum += frames[index].FirstRoll + frames[index + 1].FirstRoll + (frames[index + 1].SecondRoll.HasValue ? frames[index + 1].SecondRoll.Value : 0);
                            }

                            if (frames[index + 1].State == FrameState.Strike && elementsAhead == 1 && round == 9)
                            {
                                sum += frames[index].FirstRoll + frames[index + 1].FirstRoll + (frames[index + 1].SecondRoll.HasValue ? frames[index + 1].SecondRoll.Value : 0);
                            }
                        }
                    }
                    else if (frames[index].State == FrameState.Spare)
                    {
                        if (round < frames.Count)
                        {
                            sum += frames[index].FirstRoll + (frames[index].SecondRoll.HasValue ? frames[index].SecondRoll.Value : 0);
                            var bonus = frames[index + 1].FirstRoll;

                            sum += bonus;
                        }
                    }
                    else
                    {
                        if (frames[index].State != FrameState.Unfinished)
                        {
                            sum += frames[index].FirstRoll + (frames[index].SecondRoll.HasValue ? frames[index].SecondRoll.Value : 0);
                        }
                    }
                }
                else
                {
                    sum += frames[index].FirstRoll + (frames[index].SecondRoll.HasValue ? frames[index].SecondRoll.Value : 0) + (frames[index].BonusRoll.HasValue ? frames[index].BonusRoll.Value : 0);
                }

                index++;
            } while (index < frames.Count);

            return sum;
        }
    }
}