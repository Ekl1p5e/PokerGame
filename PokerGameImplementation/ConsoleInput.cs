using PokerGameImplementation.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PokerGameImplementation
{
    /// <summary>
    /// A class for receiving input
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConsoleInput : IUserInput
    {
        private const string Prompt = "Enter the system codes for two hands of cards:";

        /// <summary>
        /// Returns input from console
        /// </summary>
        /// <returns>string input</returns>
        public string GetInput()
        {
            Console.WriteLine(Prompt);

            return Console.ReadLine();
        }
    }
}
