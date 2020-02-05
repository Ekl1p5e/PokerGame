using PokerGame.Interfaces;
using PokerGame.Interfaces.Entities;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Rankings.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that contains two pairs
    /// </summary>
    public class TwoPair : HandRanking
    {
        private const int GROUP_NUMBER = 2;

        internal TwoPair(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.TwoPair;

        internal IEnumerable<CardValue> PairValues => Hand.GetKindGroup(GROUP_NUMBER).Select(group => group.Key);

        internal IEnumerable<Card> Kickers => Hand.GetKickers(Hand.GetFlattenedKindGroup(GROUP_NUMBER));

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as TwoPair;
            if (PairValues.SequenceEqual(right.PairValues))
            {
                return Kickers.IsGreaterSequence(right.Kickers);
            }

            return 0;
        }
    }
}
