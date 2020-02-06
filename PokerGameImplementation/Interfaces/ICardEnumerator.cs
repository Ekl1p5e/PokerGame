using PokerGame.Interfaces;
using System.Collections.Generic;

namespace PokerGameImplementation.Interfaces
{
    /// <summary>
    /// Interface for enumerating over a collection of cards
    /// </summary>
    public interface ICardEnumerator : IEnumerable<ICard> { }
}
