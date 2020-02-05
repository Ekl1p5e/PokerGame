using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;

namespace Poker.Interfaces
{
    /// <summary>
    /// Interface for getting the result of a poker game
    /// </summary>
    public interface IPokerGame
    {
        /// <summary>
        /// Gets the result of game between two poker hands
        /// </summary>
        /// <param name="leftHand">Hand of cards</param>
        /// <param name="rightHand">Hand of cards</param>
        /// <returns>Result of game</returns>
        GameResult GetResult(IHand leftHand, IHand rightHand);
    }
}
