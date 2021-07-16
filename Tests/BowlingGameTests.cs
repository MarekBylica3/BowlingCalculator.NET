using Xunit;
using BowlingApp.Src;
using BowlingApp.Enums;
using BowlingApp.Models;
using System.Collections.Generic;

namespace Tests
{
    public class BowlingGameTests
    {
        private Bowling _bowling;

        public BowlingGameTests()
        {
            _bowling = new Bowling();
        }

        [Theory]
        [MemberData(nameof(ListOfFrames))]
        public void CalculatePointsTest(List<Frame> frames, int expected)
        {
            var result = _bowling.CalculatePoints(frames);

            Assert.Equal(expected, result.Model);
        }

        public static IEnumerable<object[]> ListOfFrames =>
            new List<object[]>
            {
                new object[] { new List<Frame> {
                    new Frame(-1, 11, 1), new Frame(10, 0, 1), new Frame(10, 0, 1),
                    new Frame(10, 0, 1), new Frame(10, 0, 1), new Frame(10, 0, 1),
                    new Frame(10, 0, 1), new Frame(10, 0, 1), new Frame(10, 0, 1),
                    new Frame(10, 10, 10, 1)
                }, 0 },

                new object[] { new List<Frame> {
                    new Frame(10, 0, 1), new Frame(10, 0, 1), new Frame(10, 0, 1),
                }, 30 },

                new object[] { new List<Frame> {
                    new Frame(1, 9, 1), new Frame(1, 9, 2), new Frame(1, 9, 3),
                    new Frame(1, 9, 4), new Frame(1, 9, 5), new Frame(1, 9, 6),
                    new Frame(1, 9, 7), new Frame(1, 9, 8), new Frame(1, 9, 9),
                    new Frame(1, 9, 9, 10)
                }, 118 },

                    new object[] { new List<Frame> {
                    new Frame(10, 0, 1), new Frame(9, 1, 2), new Frame(10, 0, 3),
                    new Frame(0, 10, 4), new Frame(10, 0, 5), new Frame(7, 3, 6),
                    new Frame(8, 2, 7), new Frame(0, 10, 8), new Frame(7, 3, 9),
                    new Frame(10, 6, 4, 10)
                }, 185 },

                new object[] { new List<Frame> {
                    new Frame(9, 1, 1), new Frame(9, 1, 2), new Frame(9, 1, 3),
                    new Frame(9, 1, 4), new Frame(9, 1, 5), new Frame(9, 1, 6),
                    new Frame(9, 1, 7), new Frame(9, 1, 8), new Frame(9, 1, 9),
                    new Frame(9, 1, 9, 10)
                }, 190 },

                new object[] { new List<Frame> {
                    new Frame(10, 0, 1), new Frame(10, 0, 1), new Frame(10, 0, 1),
                    new Frame(10, 0, 1), new Frame(10, 0, 1), new Frame(10, 0, 1),
                    new Frame(10, 0, 1), new Frame(10, 0, 1), new Frame(10, 0, 1),
                    new Frame(10, 10, 10, 1)
                }, 300 },
            };

        [Theory]
        [MemberData(nameof(Frames))]
        public void FrameStateTest(Frame frame, FrameState expected)
        {
            Assert.Equal(frame.State, expected);
        }

        public static IEnumerable<object[]> Frames =>
            new List<object[]>
            {
                        new object[] { new Frame(0, 0, 10), FrameState.Miss },
                        new object[] { new Frame(1, 8, 10), FrameState.OpenFrame },
                        new object[] { new Frame(4, 3, 10), FrameState.OpenFrame },
                        new object[] { new Frame(9, 0, 10), FrameState.OpenFrame },
                        new object[] { new Frame(10, 0, 0), FrameState.Strike },
                        new object[] { new Frame(9, 1, 0), FrameState.Spare },
                        new object[] { new Frame(0, 10, 0), FrameState.Spare },
                        new object[] { new Frame(10, null, 0), FrameState.Strike },
                        new object[] { new Frame(9, null, 0), FrameState.Unfinished },
                        new object[] { new Frame(10, 0, 10), FrameState.Unfinished },
                        new object[] { new Frame(10, null, 10), FrameState.Unfinished },
                        new object[] { new Frame(9, null, 10), FrameState.Unfinished },
                        new object[] { new Frame(9, 1, 10), FrameState.Unfinished },
            };
    }
}
