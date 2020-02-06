using PokerGameImplementation.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PokerGameImplementation
{
    /// <summary>
    /// A class for receiving input
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConsoleOutput : IUserOutput
    {
        /// <summary>
        /// Outputs result to the console
        /// </summary>
        /// <param name="output">output string</param>
        public void Output(string output)
        {
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
