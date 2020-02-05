﻿using PokerGame.Interfaces.Enums;

namespace PokerGame.Interfaces.Entities
{
    /// <summary>
    /// Class representing a poker card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Initializes an instance of th <see cref="Card"/> class
        /// </summary>
        /// <param name="cardValue">Value of card</param>
        /// <param name="cardSuit">Suit of card</param>
        public Card(CardValue cardValue, CardSuit cardSuit)
        {
            Suit = cardSuit;
            Value = cardValue;
        }

        /// <summary>
        /// Gets the suit of the card
        /// </summary>
        public CardSuit Suit { get; }

        /// <summary>
        /// Gets the value of the card
        /// </summary>
        public CardValue Value { get; }
    }
}
