using PokerGame.Interfaces;
using PokerGameImplementation.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameImplementation
{
    /// <summary>
    /// Class that gathers codes from user
    /// </summary>
    public class ConsoleCodeInput : ICardEnumerator
    {
        private const string Prompt = "Enter the system codes for two hands of cards:";

        private readonly IEnumerable<ICard> _cards;

        /// <summary>
        /// Initializes an instance of the <see cref="ConsoleCodeInput"/> class
        /// </summary>
        /// <param name="converter">Converter used to create cards from input</param>
        /// <param name="count">Number of codes expected from user</param>
        public ConsoleCodeInput(ICodeConverter converter, int count)
        {
            Console.WriteLine(Prompt);

            var input = Console.ReadLine();
            var codes = input.Trim().Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Distinct();

            if (codes.Count() == count)
            {
                _cards = codes.Select(code => converter.GetCard(code));
            }
            else
            {
                throw new FormatException($"Input does not contain the expected number distinct of codes. Expected {count}, Actual count was {codes.Count()}");
            }
        }

        /// <summary>
        /// Enumerator for cards
        /// </summary>
        /// <returns>enumerator for cards collection</returns>
        public IEnumerator<ICard> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
