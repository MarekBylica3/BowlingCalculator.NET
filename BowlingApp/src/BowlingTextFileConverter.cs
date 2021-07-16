using System.Linq;
using BowlingApp.Models;
using Common.Validation;
using BowlingApp.Resources;
using System.Collections.Generic;

namespace BowlingApp.Src
{
    public class BowlingTextFileConverter : IBowlingTextFileConverter
    {
        private readonly IBowlingTextFileValidator _bowlingTextFileValidator;

        public BowlingTextFileConverter()
        {
            _bowlingTextFileValidator = new BowlingTextFileValidator();
        }

        public Result<List<Frame>> ConvertToFrames(IEnumerable<string> values)
        {
            var result = new Result<List<Frame>>();

            var converToKnockedPinsResult = ConvertToKnockedPins(values);
            if (converToKnockedPinsResult.IsValid)
            {
                var converToFramesResult = ConvertToFrames(converToKnockedPinsResult.Model);
                if (converToFramesResult.IsValid)
                {
                    result.Model = converToFramesResult.Model;
                }
                else
                {
                    result.AddError(converToFramesResult.ErrorMessage);
                }
            }
            else
            {
                result.AddError(converToKnockedPinsResult.ErrorMessage);
            }

            return result;
        }

        private Result<List<int>> ConvertToKnockedPins(IEnumerable<string> values)
        {
            var result = new Result<List<int>>();

            bool noMoreThan21Throws = _bowlingTextFileValidator.NoMoreThan21Throws(values.Count());

            if (noMoreThan21Throws)
            {
                foreach (var value in values)
                {
                    var validationResult = ValidateSingleValue(value);
                    if (validationResult.IsValid)
                    {
                        result.Model.Add(validationResult.Model);
                    }
                    else
                    {
                        result.AddError(validationResult.ErrorMessage);
                    }
                }
            }
            else
            {
                result.AddError(BowlingResources.FileValuesCountError);
            }

            return result;
        }

        private Result<List<Frame>> ConvertToFrames(List<int> pins)
        {
            var result = new Result<List<Frame>>();
            var index = 0;
            var frameNumber = 1;
            do
            {
                Frame frame;
                if (result.Model.Count != 9)
                {
                    if (pins[index] == 10)
                    {
                        frame = new Frame(10, 0, frameNumber);
                    }
                    else
                    {
                        if (index < pins.Count - 1)
                        {
                            if (pins[index] + pins[index + 1] <= 10)
                            {
                                frame = new Frame(pins[index], pins[index + 1], frameNumber);
                                index++;
                            }
                            else
                            {
                                result.AddError(BowlingResources.FrameConversionError);
                                break;
                            }
                        }
                        else
                        {
                            frame = new Frame(pins[index], null, frameNumber);
                        }
                    }
                }
                else
                {
                    if (pins.Count - (index + 1) == 0)
                    {
                        frame = new Frame(pins[index], null, frameNumber);
                    }
                    else
                    {
                        frame = new Frame(pins[index], pins[index + 1], frameNumber);

                        if (pins.Count - (index + 1) == 2 && (pins[index] == 10 || pins[index] + pins[index + 1] == 10))
                        {
                            frame.SetBonusRoll(pins[index + 2]);
                            index++;
                        }

                        index++;
                    }
                }

                if (frame != null)
                {
                    result.Model.Add(frame);
                }

                index++;
                frameNumber++;
            } while (result.IsValid && index < pins.Count && frameNumber <= 10);

            return result;
        }

        private Result<int> ValidateSingleValue(string value)
        {
            var result = new Result<int>();

            bool isNumber = _bowlingTextFileValidator.IsNumber(value);

            if (isNumber)
            {
                int valueAsNumber = int.Parse(value);
                bool isInRange = _bowlingTextFileValidator.IsInRange(valueAsNumber);

                if (isInRange)
                {
                    result.Model = valueAsNumber;
                }
                else
                {
                    result.AddError(BowlingResources.NumberNotInRangerError);
                }
            }
            else
            {
                result.AddError(BowlingResources.ValueIsNotNumberError);
            }

            return result;
        }
    }
}
