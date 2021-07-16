using Xunit;
using BowlingApp;
using System.Collections.Generic;

namespace Tests
{
    public class BowlingTextFileConverterTests
    {
        private IBowlingTextFileConverter _bowlingTextFileConverter;

        public BowlingTextFileConverterTests()
        {
            _bowlingTextFileConverter = new BowlingTextFileConverter();
        }

        [Theory]
        [MemberData(nameof(LinesFromFile))]
        public void ValidateConversionToFramesTest(string[] lines, bool expected)
        {
            var result = _bowlingTextFileConverter.ConvertToFrames(lines);

            Assert.Equal(expected, result.IsValid);
        }

        public static IEnumerable<object[]> LinesFromFile =>
            new List<object[]>
            {
                new object[] { new List<string> {}, false },
                new object[] { new List<string> { "" }, false },
                new object[] { new string[] { "6", "3","1","3","1","2","3","1","2","3", "1", "2", "3", "4","2","1","2","3","4","1","2","3" }, false }, // 22 elements
                new object[] { new string[] { "6", "3","1","3","1","2","3","1","2","3","1","2","3","4","2","1","2","3","4","1","2" }, true }, // 21 elements
                new object[] { new string[] { "6","3","1","3","1","2","3","1","2","3","1","2","3" }, true },
                new object[] { new string[] { "6", "3","11" }, false }, // Element in array is > 10
                new object[] { new string[] { "6", "3","-1" }, false }, // Element in array is < 0
            };
    }
}
