using PokerGame.Interfaces;
using PokerGameImplementation.Enums;

namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand where cards are in sequential order, regardless of suit
    /// </summary>
    public class Straight : HandRanking
    {
        internal Straight(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.Straight;

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as Straight;
            return Hand.IsGreaterSequence(right.Hand);
        }
    }
}
