using BowlingApp.Enums;

namespace BowlingApp.Models
{
    public class Frame
    {
        public int FrameNumber { get; }
        public int FirstRoll { get; }
        public int? SecondRoll { get; }
        public int? BonusRoll { get; private set; }
        public FrameState State
        {
            get
            {
                var state = FrameState.OpenFrame;

                if (SecondRoll.HasValue)
                {
                    if (FirstRoll + SecondRoll.Value == 10)
                        state = FrameState.Spare;
                    else if (FirstRoll + SecondRoll.Value == 0)
                        state = FrameState.Miss;

                    if (FrameNumber == 10 && FirstRoll + SecondRoll.Value == 10 && !BonusRoll.HasValue)
                    {
                        state = FrameState.Unfinished;
                    }
                }
                else
                {
                    state = FrameState.Unfinished;
                }

                if (FirstRoll == 10)
                    state = FrameState.Strike;

                if (FrameNumber == 10 && FirstRoll == 10 && !BonusRoll.HasValue)
                {
                    state = FrameState.Unfinished;
                }

                return state;
            }
        }

        public Frame(int firstRoll, int? secondRoll, int frameNumber)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
            FrameNumber = frameNumber;
        }

        public Frame(int firstRoll, int? secondRoll, int? bonusRoll, int frameNumber)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
            BonusRoll = bonusRoll;
            FrameNumber = frameNumber;
        }

        public void SetBonusRoll(int points)
        {
            BonusRoll = points;
        }

        public bool Validate()
        {
            var result = true;

            if (FirstRoll > 10 || FirstRoll < 0)
                result = false;

            if (SecondRoll.HasValue)
            {
                if (SecondRoll.Value > 10 || SecondRoll.Value < 0)
                    result = false;
            }

            if (BonusRoll.HasValue)
            {
                if (BonusRoll.Value > 10 || BonusRoll.Value < 0)
                    result = false;
            }

            return result;
        }
    }
}
