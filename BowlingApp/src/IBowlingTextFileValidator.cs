using Common.Validation;
using System.Collections.Generic;

namespace BowlingApp.Src
{
    public interface IBowlingTextFileValidator
    {
        Result<List<string>> ValidateFileFormat(IEnumerable<string> lines);
        bool IsNumber(string value);
        bool IsInRange(int value);
        bool NoMoreThan21Throws(int throwsCount);
    }
}
