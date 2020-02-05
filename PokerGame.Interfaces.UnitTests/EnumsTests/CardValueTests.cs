using PokerGame.Interfaces.Enums;
using Xunit;

namespace PokerGame.Interfaces.UnitTests.EnumsTests
{
    public class CardValueTests
    {
        [Theory]
        [InlineData(CardValue.Ace, CardValue.King)]
        [InlineData(CardValue.King, CardValue.Queen)]
        [InlineData(CardValue.Queen, CardValue.Jack)]
        [InlineData(CardValue.Jack, CardValue.Ten)]
        [InlineData(CardValue.Ten, CardValue.Nine)]
        [InlineData(CardValue.Nine, CardValue.Eight)]
        [InlineData(CardValue.Eight, CardValue.Seven)]
        [InlineData(CardValue.Seven, CardValue.Six)]
        [InlineData(CardValue.Six, CardValue.Five)]
        [InlineData(CardValue.Five, CardValue.Four)]
        [InlineData(CardValue.Four, CardValue.Three)]
        [InlineData(CardValue.Three, CardValue.Two)]
        public void CardValues_InOrder(CardValue higher, CardValue lower)
        {
            Assert.True(higher > lower);
        }
    }
}
