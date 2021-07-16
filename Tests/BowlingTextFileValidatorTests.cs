using Xunit;
using BowlingApp;
using System.Collections.Generic;

namespace Tests
{
    public class BowlingTextFileValidatorTests
    {
        private IBowlingTextFileValidator _bowlingTextFileValidator;

        public BowlingTextFileValidatorTests()
        {
            _bowlingTextFileValidator = new BowlingTextFileValidator();
        }

        [Theory]
        [MemberData(nameof(LinesFromFile))]
        public void ValidateFileFormatTest(List<string> lines, bool expected)
        {
            var result = _bowlingTextFileValidator.ValidateFileFormat(lines);

            Assert.Equal(expected, result.IsValid);
        }

        public static IEnumerable<object[]> LinesFromFile =>
            new List<object[]>
            {
                new object[] { new List<string> { "Paweł Kowalski", "6,3,1,3,1,2,3,1,2,3,1,2,3" }, true },
                new object[] { new List<string> { "", "" }, false },
                new object[] { new List<string> { "Text", "Text" }, true },
                new object[] { new List<string> { "Text", "" }, false },
                new object[] { new List<string> { " ", " " }, false },
                new object[] { new List<string> { " ", "6,5,2,1,2,3,1,2,3" }, false },
            };

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(15, true)]
        [InlineData(21, true)]
        [InlineData(22, false)]
        public void NoMoreThan21ThrowsTest(int throwsCount, bool expected)
        {
            var result = _bowlingTextFileValidator.NoMoreThan21Throws(throwsCount);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData("0", true)]
        [InlineData("-1", true)]
        [InlineData("100", true)]
        [InlineData(":(", false)]
        [InlineData("", false)]
        [InlineData("*#%&", false)]
        [InlineData(" ", false)]
        [InlineData(",", false)]
        [InlineData(".", false)]
        public void IsNumberTest(string value, bool expected)
        {
            var result = _bowlingTextFileValidator.IsNumber(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, true)]
        [InlineData(0, true)]
        [InlineData(-1, false)]
        [InlineData(11, false)]
        [InlineData(7, true)]
        public void IsInRangeTest(int value, bool expected)
        {
            var result = _bowlingTextFileValidator.IsInRange(value);

            Assert.Equal(expected, result);
        }

    }
}
