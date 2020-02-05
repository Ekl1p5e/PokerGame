namespace PokerGame.Interfaces
{
    /// <summary>
    /// Interface for ranking hands within a poker game
    /// </summary>
    public interface IHandRanker
    {
        /// <summary>
        /// Gets ranking for a hand
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <returns>Ranking of the hand</returns>
        IHandRanking GetRanking(IHand hand);
    }
}
