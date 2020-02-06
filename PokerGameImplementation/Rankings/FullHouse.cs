using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PokerGameImplementation.UnitTests")]
namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that contains a three of a kind and a two of a kind
    /// </summary>
    public class FullHouse : HandRanking
    {
        private const int THREE_KIND_GROUP_NUMBER = 3;

        private const int TWO_KIND_GROUP_NUMBER = 2;

        internal FullHouse(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.FullHouse;

        internal CardValue ThreeKind => Hand.GetFirstKindGroupCardValue(THREE_KIND_GROUP_NUMBER);

        internal CardValue TwoKind => Hand.GetFirstKindGroupCardValue(TWO_KIND_GROUP_NUMBER);

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as FullHouse;
            if (ThreeKind == right.ThreeKind)
            {
                if (TwoKind != right.TwoKind)
                {
                    return TwoKind > right.TwoKind ? 1 : -1;
                }

                return 0;
            }

            return ThreeKind > right.ThreeKind ? 1 : -1;
        }
    }
}
