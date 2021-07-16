using ConsoleTables;
using BowlingApp.Models;
using BowlingApp.Resources;
using System.Collections.Generic;

namespace BowlingApp.Src
{
    public class BowlingScoreFormatter : IBowlingScoreFormatter
    {
        private readonly string STRIKE_MARK = "X";
        private readonly string SPARE_MARK = "/";

        public void DisplayScoreBoard(Player player, int finalPoints)
        {
            var headers = new List<string>();
            headers.Add(BowlingResources.PlayerNameHeader);
            headers.Add(BowlingResources.ScoreHeader);

            foreach (var frame in player.Frames)
            {
                headers.Add(frame.FrameNumber.ToString());
            }

            var table = new ConsoleTable(new ConsoleTableOptions()
            { 
                EnableCount = false
            });

            table.AddColumn(headers.ToArray());

            var cellValues = new List<object>();

            cellValues.Add(player.Name);
            cellValues.Add(finalPoints);

            foreach (var frame in player.Frames)
            {
                var first = frame.FirstRoll.ToString();
                var second = frame.SecondRoll.HasValue ? frame.SecondRoll.ToString() : string.Empty;
                var bonus = frame.BonusRoll.HasValue ? frame.BonusRoll.ToString() : string.Empty;

                if (frame.FirstRoll == 10 && !frame.BonusRoll.HasValue)
                {
                    first = string.Empty;
                    second = STRIKE_MARK;
                }
                else
                {
                    if (frame.SecondRoll.HasValue)
                    {
                        if (frame.FirstRoll + frame.SecondRoll.Value == 10)
                        {
                            second = SPARE_MARK;
                        }
                    }
                }

                cellValues.Add($"{first} {second} {bonus}");
            }

            table.AddRow(cellValues.ToArray());
            table.Write();
        }
    }
}
