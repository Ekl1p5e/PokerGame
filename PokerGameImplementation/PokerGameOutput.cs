using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
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

        /// <summary>
        /// Outputs the result of a poker game
        /// </summary>
        /// <param name="result"></param>
        public void Output(GameResult result)
        {
            switch (result)
            {
                case GameResult.Draw:
                    Console.WriteLine(GAME_DRAW_OUTPUT);
                    break;
                case GameResult.LeftHandWinner:
                    Console.WriteLine(GAME_LEFT_WINNER_OUTPUT);
                    break;
                case GameResult.RightHandWinner:
                    Console.WriteLine(GAME_RIGHT_WINNER_OUTPUT);
                    break;
                default:
                    Console.WriteLine(GAME_DEFAULT_OUTPUT);
                    break;
            }

            Console.ReadLine();
        }
    }
}
