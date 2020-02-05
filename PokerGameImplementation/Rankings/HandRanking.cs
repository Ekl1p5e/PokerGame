using PokerGame.Interfaces;
using PokerGameImplementation.Rankings.Enums;
using System;

namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Base class for poker hand rankings
    /// </summary>
    public abstract class HandRanking : IHandRanking
    {
        protected HandRanking(IHand hand)
        {
            Hand = hand ?? throw new ArgumentNullException(nameof(hand));
        }

        internal IHand Hand { get; }

        protected abstract HandRank Rank { get; }

        protected abstract int TieBreaker(HandRanking other);

        /// <summary>
        /// Compares hand rankings
        /// </summary>
        /// <param name="other">hand ranking</param>
        /// <returns>
        /// -1 if other hand ranking is higher
        /// 0 if other hand ranking is the same
        /// 1 if other hand ranking is less
        /// </returns>
        /// <exception cref="ArgumentException">Throws an exception if class is not <see cref="HandRanking"/> class</exception>
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