using System.Collections.Generic;

namespace BowlingApp.Models
{
    public class Player
    {
        public string Name { get; private set;  }
        public List<Frame> Frames { get; private set; } = new List<Frame>();

        public Player()
        {
        }

        public Player(string name)
        {
            Name = name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void AddFrame(Frame frame)
        {
            Frames.Add(frame);
        }

        public void AddFrames(List<Frame> frames)
        {
            Frames.AddRange(frames);
        }
    }
}