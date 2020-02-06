using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Enums;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PokerGameImplementation.UnitTests")]
namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that contains four of a kind
    /// </summary>
    public class FourOfAKindHand : HandRanking
    {
        private const int GROUP_NUMBER = 4;

        internal FourOfAKindHand(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.FourOfAKind;

        internal CardValue Kind => Hand.GetFirstKindGroupCardValue(GROUP_NUMBER);

        internal IEnumerable<ICard> Kickers => Hand.GetKickers(Hand.GetFlattenedKindGroup(GROUP_NUMBER));

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as FourOfAKindHand;
            if (Kind == right.Kind)
            {
                return Kickers.CompareSequenceTo(right.Kickers);
            }

            return Kind > right.Kind ? 1 : -1;
        }
    }
}
