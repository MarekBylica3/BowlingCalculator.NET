using BowlingApp.Models;

namespace BowlingApp.Src
{
    public interface IBowlingScoreFormatter
    {
        public void DisplayScoreBoard(Player player, int finalPoints);
    }
}
