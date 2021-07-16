using System;
using System.Linq;
using Common.Validation;
using Common.Extensions;
using BowlingApp.Models;
using System.Collections.Generic;

namespace BowlingApp.Src
{
    public class BowlingTextFileParser : IBowlingDataParser
    {
        private readonly string FIELD_DELIMITER = Environment.NewLine;
        private readonly string VALUES_DELIMITER = ",";

        private readonly IBowlingTextFileValidator _bowlingTextFileValidator;
        private readonly IBowlingTextFileConverter _bowlingTextFileConverter;

        public BowlingTextFileParser()
        {
            _bowlingTextFileValidator = new BowlingTextFileValidator();
            _bowlingTextFileConverter = new BowlingTextFileConverter();
        }

        public Result<List<Result<Player>>> Parse(string textFile)
        {
            var lines = textFile.Split(FIELD_DELIMITER);
            return Parse(lines);
        }

        public Result<List<Result<Player>>> Parse(IEnumerable<string> lines)
        {
            var result = new Result<List<Result<Player>>>();

            var fileFormatResult = _bowlingTextFileValidator.ValidateFileFormat(lines);

            if (fileFormatResult.IsValid)
            {
                for (int i = 0; i < fileFormatResult.Model.Count(); i += 2)
                {
                    var validateParseObjResult = ValidateParseObj(fileFormatResult.Model[i], fileFormatResult.Model[i + 1]);
                    result.Model.Add(validateParseObjResult);
                }
            }
            else
            {
                result.AddError(fileFormatResult.ErrorMessage);
            }

            return result;
        }

        private Result<Player> ValidateParseObj(string name, string values)
        {
            var result = new Result<Player>();
            result.Model.SetName(name);

            var parseScoresResult = ParseScores(values);

            if (parseScoresResult.IsValid)
            {                
                result.Model.AddFrames(parseScoresResult.Model);
            }
            else
            {
                result.AddError(parseScoresResult.ErrorMessage);
            }

            return result;
        }

        private Result<List<Frame>> ParseScores(string line)
        {
            var result = new Result<List<Frame>>();

            var scores = line
                .RemoveWhitespace()
                .Split(VALUES_DELIMITER)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();

            var frameResult = _bowlingTextFileConverter.ConvertToFrames(scores);

            if (frameResult.IsValid)
            {
                result.Model = frameResult.Model;
            }
            else
            {
                result.AddError(frameResult.ErrorMessage);
            }

            return result;
        }
    }
}
