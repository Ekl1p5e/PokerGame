using PokerGame.Interfaces;

namespace PokerGameImplementation.Interfaces
{
    /// <summary>
    /// Interface for an object that does code to card conversions
    /// </summary>
    public interface ICodeConverter
    {
        /// <summary>
        /// Converts a code to a card
        /// </summary>
        /// <param name="code">code representing a card</param>
        /// <returns>A poker game card</returns>
        ICard GetCard(string code);
    }
}
