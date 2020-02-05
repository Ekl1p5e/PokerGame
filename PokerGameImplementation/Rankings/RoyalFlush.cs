using PokerGame.Interfaces;
using PokerGameImplementation.Rankings.Enums;

namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that has all cards of the same suit in sequential order, where the Ace is high
    /// </summary>
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
