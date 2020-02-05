using PokerGame.Interfaces;
using PokerGameImplementation.Rankings.Enums;

namespace PokerGameImplementation.Rankings
{
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
