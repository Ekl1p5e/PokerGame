using PokerGame.Interfaces;
using PokerGameImplementation.Rankings.Enums;

namespace PokerGameImplementation.Rankings
{
    public class Flush : HandRanking
    {
        internal Flush(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.Flush;

        protected override int TieBreaker(HandRanking other)
        {
            return Hand.IsGreaterSequence(other.Hand);
        }
    }
}
