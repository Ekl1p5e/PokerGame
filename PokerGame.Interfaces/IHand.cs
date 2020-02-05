using PokerGame.Interfaces.Entities;
using System.Collections.Generic;

namespace PokerGame.Interfaces
{
    /// <summary>
    /// Interface for hand within a poker game
    /// </summary>
    public interface IHand
    {
        /// <summary>
        /// Gets cards of the hand
        /// </summary>
        IEnumerable<Card> Cards { get; }
    }
}