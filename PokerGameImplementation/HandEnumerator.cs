using PokerGame.Interfaces;
using PokerGameImplementation.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameImplementation
{
    public class HandEnumerator : IHandEnumerator
    {
        private readonly int _handCardCount;
        private readonly IEnumerable<ICard> _cards;

        private readonly IEnumerator<IHand> _handEnumerator;

        public HandEnumerator(IEnumerable<ICard> cards, int handCardCount)
        {
            _cards = cards ?? throw new ArgumentNullException(nameof(cards));
            _handCardCount = handCardCount;

            _handEnumerator = GetEnumerator();
        }

        public IEnumerator<IHand> GetEnumerator()
        {
            for (var skipBy = 0; skipBy < _cards.Count(); skipBy += _handCardCount)
            {
                yield return new PokerHand(_cards.Skip(skipBy).Take(_handCardCount));
            }
        }

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
