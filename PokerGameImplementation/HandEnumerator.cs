using PokerGame.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameImplementation
{
    /// <summary>
    /// Creates hands of cards from a collection
    /// </summary>
    public class HandEnumerator : IHandEnumerator
    {
        private readonly int _handCardCount;
        private readonly IEnumerable<ICard> _cards;
        private readonly IEnumerator<IHand> _handEnumerator;

        /// <summary>
        /// Initializes an instance of the <see cref="HandEnumerator"/> class
        /// </summary>
        /// <param name="cards">collection of cards</param>
        /// <param name="handCardCount">hand card count</param>
        public HandEnumerator(IEnumerable<ICard> cards, int handCardCount)
        {
            _cards = cards ?? throw new ArgumentNullException(nameof(cards));
            _handCardCount = handCardCount;

            _handEnumerator = GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator for hands of cards
        /// </summary>
        /// <returns>interface for a enumerating over hands of cards</returns>
        public IEnumerator<IHand> GetEnumerator()
        {
            for (var skipBy = 0; skipBy < _cards.Count(); skipBy += _handCardCount)
            {
                yield return new PokerHand(_cards.Skip(skipBy).Take(_handCardCount));
            }
        }

        /// <summary>
        /// Gets next hand from enumerator
        /// </summary>
        /// <returns>A hand of cards</returns>
        public IHand NextHand()
        {
            IHand hand = null;
            if (_handEnumerator.MoveNext())
            {
                hand = _handEnumerator.Current;
            }

            return hand;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
