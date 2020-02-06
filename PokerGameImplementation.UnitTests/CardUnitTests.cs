using PokerGame.Interfaces.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace PokerGameImplementation.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class CardUnitTests
    {
        public static IEnumerable<object[]> CardEnums
        {
            get
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                    {
                        yield return new object[] { value, suit };
                    }
                }
            }
        }

        [Theory]
        [MemberData(nameof(CardEnums))]
        public void Constructor_SetsValues_FromConstructorArguments(CardValue cardValue, CardSuit cardSuit)
        {
            var card = new Card(cardValue, cardSuit);

            Assert.Equal(cardValue, card.Value);
            Assert.Equal(cardSuit, card.Suit);
        }
    }
}
