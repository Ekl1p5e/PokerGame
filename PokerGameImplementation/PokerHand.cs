using PokerGame.Interfaces;
using System.Collections.Generic;

namespace PokerGameImplementation
{
    public class PokerHand : IHand
    {
        public PokerHand(IEnumerable<ICard> cards)
        {
            Cards = cards;
        }

        public IEnumerable<ICard> Cards { get; }
    }
}
