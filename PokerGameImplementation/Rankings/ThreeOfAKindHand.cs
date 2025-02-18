﻿using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Enums;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PokerGameImplementation.UnitTests")]
namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that contains three of a kind
    /// </summary>
    public class ThreeOfAKindHand : HandRanking
    {
        private const int GROUP_NUMBER = 3;

        internal ThreeOfAKindHand(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.ThreeOfAKind;

        internal CardValue Kind => Hand.GetFirstKindGroupCardValue(GROUP_NUMBER);

        internal IEnumerable<ICard> Kickers => Hand.GetKickers(Hand.GetFlattenedKindGroup(GROUP_NUMBER));

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as ThreeOfAKindHand;
            if (Kind == right.Kind)
            {
                return Kickers.CompareSequenceTo(right.Kickers);
            }

            return Kind > right.Kind ? 1 : -1;
        }
    }
}
