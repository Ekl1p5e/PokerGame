using PokerGame.Interfaces;
using System;
using System.Collections.Generic;

namespace PokerGameImplementation
{
    /// <summary>
    /// Class of poker hand of cards
    /// </summary>
    public class PokerHand : IHand
    {
        /// <summary>
        /// Initializes an instance of <see cref="PokerHand"/> class
        /// </summary>
        /// <param name="cards">cards of hand</param>
        public PokerHand(IEnumerable<ICard> cards)
        {
            Cards = cards ?? throw new ArgumentNullException(nameof(cards));
        }

        /// <summary>
        /// Gets cards of hand
        /// </summary>
        public IEnumerable<ICard> Cards { get; }
    }
}
