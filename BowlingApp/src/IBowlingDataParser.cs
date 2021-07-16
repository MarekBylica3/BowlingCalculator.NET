using BowlingApp.Models;
using Common.Validation;
using System.Collections.Generic;

namespace BowlingApp.Src
{
    public interface IBowlingDataParser
    {
        Result<List<Result<Player>>> Parse(string file);
        Result<List<Result<Player>>> Parse(IEnumerable<string> lines);
    }
}
