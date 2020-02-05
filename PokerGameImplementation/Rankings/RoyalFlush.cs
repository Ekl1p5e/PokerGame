using PokerGame.Interfaces;
using PokerGameImplementation.Rankings.Enums;

namespace PokerGameImplementation.Rankings
{
    public class RoyalFlush : HandRanking
    {
        internal RoyalFlush(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.RoyalFlush;

        protected override int TieBreaker(HandRanking other)
        {
            return 0;
        }
    }
}
