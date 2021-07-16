using BowlingApp.Models;
using Common.Validation;
using System.Collections.Generic;

namespace BowlingApp.Src
{
    public interface IBowlingTextFileConverter
    {
        Result<List<Frame>> ConvertToFrames(IEnumerable<string> values);
    }
}
