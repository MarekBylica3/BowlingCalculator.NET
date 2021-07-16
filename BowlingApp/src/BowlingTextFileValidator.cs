using System.Linq;
using Common.Validation;
using BowlingApp.Resources;
using System.Collections.Generic;

namespace BowlingApp.Src
{    public class BowlingTextFileValidator : IBowlingTextFileValidator
    {
        private readonly int MAX_THROWS = 21;

        public Result<List<string>> ValidateFileFormat(IEnumerable<string> lines)
        {
            var result = new Result<List<string>>();

            lines = lines
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.TrimStart().TrimEnd())
                .ToList();

            if (!lines.Any() || lines.Count() % 2 != 0)
            {
                result.AddError(BowlingResources.FileFormatValidationError);
            }
            else
            {
                result.Model = lines.ToList();
            }

            return result;
        }

        public bool IsNumber(string value)
        {
            int number;
            var result = int.TryParse(value, out number);

            return result;
        }

        public bool IsInRange(int value)
        {
            var result = true;

            if (!(value >= 0 && value <= 10))
            {
                result = false;
            }

            return result;
        }

        public bool NoMoreThan21Throws(int throwsCount)
        {
            var result = true;

            if (throwsCount == 0 || throwsCount > MAX_THROWS)
            {
                result = false;
            }

            return result;
        }
    }
}
