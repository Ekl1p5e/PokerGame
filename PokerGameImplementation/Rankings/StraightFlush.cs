using PokerGame.Interfaces;
using PokerGame.Interfaces.Entities;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Rankings.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameImplementation.Rankings
{
    public class StraightFlush : HandRanking
    {
        private const int GROUP_NUMBER = 2;

        internal StraightFlush(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.StraightFlush;

        public CardValue PairValue => Hand.GetFirstKindGroupCardValue(GROUP_NUMBER);

        public IEnumerable<Card> Kickers => Hand.GetKickers(Hand.GetFlattenedKindGroup(GROUP_NUMBER));

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
