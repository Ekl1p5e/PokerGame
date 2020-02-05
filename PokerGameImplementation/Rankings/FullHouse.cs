using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Rankings.Enums;

namespace PokerGameImplementation.Rankings
{
    public class FullHouse : HandRanking
    {
        private const int THREE_KIND_GROUP_NUMBER = 3;

        private const int TWO_KIND_GROUP_NUMBER = 2;

        internal FullHouse(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.FullHouse;

        public CardValue ThreeKind => Hand.GetFirstKindGroupCardValue(THREE_KIND_GROUP_NUMBER);

        public CardValue TwoKind => Hand.GetFirstKindGroupCardValue(TWO_KIND_GROUP_NUMBER);

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
