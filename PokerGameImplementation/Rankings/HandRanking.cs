using PokerGame.Interfaces;
using PokerGameImplementation.Rankings.Enums;
using System;

namespace PokerGameImplementation.Rankings
{
    public abstract class HandRanking : IHandRanking
    {
        protected HandRanking(IHand hand)
        {
            Hand = hand ?? throw new ArgumentNullException(nameof(hand));
        }

        internal IHand Hand { get; }

        protected abstract HandRank Rank { get; }

        protected abstract int TieBreaker(HandRanking other);

        public int CompareTo(IHandRanking other)
        {
            if (other is HandRanking ranking)
            {
                if (Rank > ranking.Rank)
                {
                    return 1;
                }
                else if (Rank < ranking.Rank)
                {
                    return -1;
                }
                else
                {
                    TieBreaker(ranking);
                }
            }

            throw new ArgumentException($"Argument not of type {nameof(HandRanking)}", nameof(other));
        }
    }
}