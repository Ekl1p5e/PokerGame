using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameImplementation
{
    public class PokerCodesConverter : ICodeConverter
    {
        private readonly Dictionary<string, Card> _cardCache = new Dictionary<string, Card>();

        private readonly static Dictionary<char, CardSuit> _suits = new Dictionary<char, CardSuit>
        {
            { 'H', CardSuit.Hearts },
            { 'D', CardSuit.Diamonds },
            { 'S', CardSuit.Spades },
            { 'C', CardSuit.Clubs },
        };

        private readonly static Dictionary<char, CardValue> _values = new Dictionary<char, CardValue>
        {
            { '2', CardValue.Two },
            { '3', CardValue.Three },
            { '4', CardValue.Four },
            { '5', CardValue.Five },
            { '6', CardValue.Six },
            { '7', CardValue.Seven },
            { '8', CardValue.Eight },
            { '9', CardValue.Nine },
            { 'T', CardValue.Ten },
            { 'J', CardValue.Jack },
            { 'Q', CardValue.Queen },
            { 'K', CardValue.King },
            { 'A', CardValue.Ace },
        };

        public ICard GetCard(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Code is null or empty", nameof(code));
            }

            var upperCase = code.ToUpper();
            if (upperCase.Length == 2 &&
                _values.TryGetValue(upperCase.First(), out var value) &&
                _suits.TryGetValue(upperCase.Last(), out var suit))
            {
                if (!_cardCache.TryGetValue(code, out _))
                {
                    _cardCache[code] = new Card(value, suit);
                }

                return _cardCache[code];
            }

            throw new ArgumentException("Code is invalid", nameof(code));
        }
    }
}
