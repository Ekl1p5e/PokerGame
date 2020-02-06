using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PokerGameImplementation.UnitTests")]
namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that has all cards of the same suit in sequential order
    /// </summary>
    public class StraightFlush : HandRanking
    {
        private const int GROUP_NUMBER = 2;

        internal StraightFlush(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.StraightFlush;

        internal CardValue PairValue => Hand.GetFirstKindGroupCardValue(GROUP_NUMBER);

        internal IEnumerable<ICard> Kickers => Hand.GetKickers(Hand.GetFlattenedKindGroup(GROUP_NUMBER));

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as StraightFlush;
            if (Hand.Cards.Max(card => card.Value) != right.Hand.Cards.Max(card => card.Value))
            {
                return Hand.Cards.Max(card => card.Value) > right.Hand.Cards.Max(card => card.Value) ? 1 : -1;
            }

            return 0;
        }
    }
}
