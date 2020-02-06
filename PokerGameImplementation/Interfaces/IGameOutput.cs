using PokerGame.Interfaces.Enums;

namespace PokerGameImplementation.Interfaces
{
    /// <summary>
    /// Interface that allows for the handling of a game result
    /// </summary>
    public interface IGameOutput
    {
        /// <summary>
        /// Sends game result
        /// </summary>
        /// <param name="result">game result</param>
        void Output(GameResult result);
    }
}
