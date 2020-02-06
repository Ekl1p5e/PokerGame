using PokerGame.Interfaces.Enums;
using System;

namespace PokerGame.Interfaces
{
    /// <summary>
    /// Interface to be implemented for cards within a poker game
    /// </summary>
    public interface ICard : IEquatable<ICard>
    {
        /// <summary>
        /// Gets the suit of the card
        /// </summary>
        CardSuit Suit { get; }

        /// <summary>
        /// Gets the value of the card
        /// </summary>
        CardValue Value { get; }
    }
}