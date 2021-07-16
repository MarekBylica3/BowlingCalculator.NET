using BowlingApp.Models;
using Common.Validation;
using System.Collections.Generic;

namespace BowlingApp.Src
{
    public interface IBowling
    {
        List<Player> Players { get; }
        Result LoadGame(string textFile);
        Result<int> CalculatePoints(List<Frame> frames);
    }
}
