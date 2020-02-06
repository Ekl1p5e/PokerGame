﻿using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Enums;
using System.Collections.Generic;

namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that contains four of a kind
    /// </summary>
    public class FourOfAKind : HandRanking
    {
        private const int GROUP_NUMBER = 4;

        internal FourOfAKind(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.FourOfAKind;

        internal CardValue Kind => Hand.GetFirstKindGroupCardValue(GROUP_NUMBER);

        internal IEnumerable<ICard> Kickers => Hand.GetKickers(Hand.GetFlattenedKindGroup(GROUP_NUMBER));

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as FourOfAKind;
            if (Kind == right.Kind)
            {
                return Kickers.IsGreaterSequence(right.Kickers);
            }

            return Kind > right.Kind ? 1 : -1;
        }
    }
}
