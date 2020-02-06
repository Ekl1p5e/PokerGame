using PokerGame.Interfaces;
using PokerGameImplementation.Enums;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PokerGameImplementation.UnitTests")]
namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that has all cards of the same suit in sequential order
    /// </summary>
    public class StraightFlushHand : HandRanking
    {
        private const int GROUP_NUMBER = 2;

        internal StraightFlushHand(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.StraightFlush;

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as StraightFlushHand;
            if (Hand.Cards.Max(card => card.Value) != right.Hand.Cards.Max(card => card.Value))
            {
                return Hand.Cards.Max(card => card.Value) > right.Hand.Cards.Max(card => card.Value) ? 1 : -1;
            }

            return 0;
        }
    }
}
