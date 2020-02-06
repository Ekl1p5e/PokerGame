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
        public void Output(string result)
        {
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
