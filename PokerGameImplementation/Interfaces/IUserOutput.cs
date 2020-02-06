namespace PokerGameImplementation.Interfaces
{
    /// <summary>
    /// An interface for sending output
    /// </summary>
    public interface IUserOutput
    {
        /// <summary>
        /// Sends output
        /// </summary>
        /// <param name="result">game result to send</param>
        void Output(string result);
    }
}
