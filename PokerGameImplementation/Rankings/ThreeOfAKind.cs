using PokerGame.Interfaces;
using PokerGame.Interfaces.Entities;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Rankings.Enums;
using System.Collections.Generic;

namespace PokerGameImplementation.Rankings
{
    public class ThreeOfAKind : HandRanking
    {
        private const int GROUP_NUMBER = 3;

        internal ThreeOfAKind(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.ThreeOfAKind;

        internal CardValue Kind => Hand.GetFirstKindGroupCardValue(GROUP_NUMBER);

        internal IEnumerable<Card> Kickers => Hand.GetKickers(Hand.GetFlattenedKindGroup(GROUP_NUMBER));

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as ThreeOfAKind;
            if (Kind == right.Kind)
            {
                return Kickers.IsGreaterSequence(right.Kickers);
            }

            return Kind > right.Kind ? 1 : -1;
        }
    }
}
