using PokerGame.Interfaces;
using PokerGameImplementation.Rankings.Enums;

namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand where the high card is significant
    /// </summary>
    public class HighCard : HandRanking
    {
        internal HighCard(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.HighCard;

        protected override int TieBreaker(HandRanking other)
        {
            return Hand.IsGreaterSequence(other.Hand);
        }
    }
}
