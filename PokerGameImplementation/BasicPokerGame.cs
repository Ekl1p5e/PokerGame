using Poker.Interfaces;
using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using System;

namespace PokerGameImplementation
{
    /// <summary>
    /// Implementation of <see cref="IPokerGame"/> interface
    /// </summary>
    public class BasicPokerGame : IPokerGame
    {
        private readonly IHandRanker _ranker;

        /// <summary>
        /// Instantiates an instance of the <see cref="BasicPokerGame"/> class
        /// </summary>
        /// <param name="ranker">An interface for ranking a poker hand</param>
        public BasicPokerGame(IHandRanker ranker)
        {
            _ranker = ranker ?? throw new ArgumentNullException(nameof(ranker));
        }

        /// <summary>
        /// Gives winner between two poker hands
        /// </summary>
        /// <param name="leftHand">Left poker hand</param>
        /// <param name="rightHand">Right poker hand</param>
        /// <returns>Returns the game result</returns>
        public GameResult GetResult(IHand leftHand, IHand rightHand)
        {
            if (leftHand == null)
            {
                throw new ArgumentNullException(nameof(leftHand));
            }

            if (rightHand == null)
            {
                throw new ArgumentNullException(nameof(rightHand));
            }

            try
            {
                if (_ranker.GetRanking(leftHand) is IHandRanking leftHandRanking &&
                    _ranker.GetRanking(rightHand) is IHandRanking rightHandRanking)
                {
                    var handComparison = leftHandRanking.CompareTo(rightHandRanking);
                    if (handComparison == 0)
                    {
                        return GameResult.Draw;
                    }
                    else if (handComparison > 0)
                    {
                        return GameResult.LeftHandWinner;
                    }
                    else
                    {
                        return GameResult.RightHandWinner;
                    }
                }
                else
                {
                    throw new InvalidOperationException($"{nameof(_ranker)} returned null reference");
                }
            }
            finally { }
        }
    }
}
