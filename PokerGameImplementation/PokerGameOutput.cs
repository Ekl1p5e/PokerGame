using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Interfaces;
using System;

namespace PokerGameImplementation
{
    /// <summary>
    /// Class that outputs the result of a poker game
    /// </summary>
    public class PokerGameOutput : IGameOutput
    {
        private const string GAME_DRAW_OUTPUT = "Draw";
        private const string GAME_LEFT_WINNER_OUTPUT = "Left Hand Wins";
        private const string GAME_RIGHT_WINNER_OUTPUT = "Right Hand Wins";
        private const string GAME_DEFAULT_OUTPUT = "";

        private readonly IUserOutput _output;

        /// <summary>
        /// Creates an instance of the <see cref="PokerGameOutput"/> class
        /// </summary>
        /// <param name="output">interface for user output</param>
        public PokerGameOutput(IUserOutput output)
        {
            _output = output;
        }

        /// <summary>
        /// Outputs the result of a poker game
        /// </summary>
        /// <param name="result"></param>
        public void Output(GameResult result)
        {
            switch (result)
            {
                case GameResult.Draw:
                    _output.Output(GAME_DRAW_OUTPUT);
                    break;
                case GameResult.LeftHandWinner:
                    _output.Output(GAME_LEFT_WINNER_OUTPUT);
                    break;
                case GameResult.RightHandWinner:
                    _output.Output(GAME_RIGHT_WINNER_OUTPUT);
                    break;
                default:
                    _output.Output(GAME_DEFAULT_OUTPUT);
                    break;
            }
        }
    }
}
