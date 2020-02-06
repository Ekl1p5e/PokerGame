using System.Collections.Generic;

namespace PokerGame.Interfaces
{
    /// <summary>
    /// Interface that gets hands for a poker game
    /// </summary>
    public interface IHandEnumerator : IEnumerable<IHand>
    {
        /// <summary>
        /// Gets next hand
        /// </summary>
        /// <returns>an interface for a hand of cards</returns>
        IHand NextHand();
    }
}
