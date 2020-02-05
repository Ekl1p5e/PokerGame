using PokerGameImplementation.Rankings.Enums;
using Xunit;

namespace PokerGameImplementation.UnitTests.EnumsTests
{
    public class HandRankUnitTests
    {
        [Theory]
        [InlineData(HandRank.RoyalFlush, HandRank.StraightFlush)]
        [InlineData(HandRank.StraightFlush, HandRank.FourOfAKind)]
        [InlineData(HandRank.FourOfAKind, HandRank.FullHouse)]
        [InlineData(HandRank.FullHouse, HandRank.Flush)]
        [InlineData(HandRank.Flush, HandRank.Straight)]
        [InlineData(HandRank.Straight, HandRank.ThreeOfAKind)]
        [InlineData(HandRank.ThreeOfAKind, HandRank.TwoPair)]
        [InlineData(HandRank.TwoPair, HandRank.OnePair)]
        [InlineData(HandRank.OnePair, HandRank.HighCard)]
        public void HandRank_HasCorrectOrdering(HandRank higher, HandRank lower)
        {
            Assert.True(higher > lower);
        }
    }
}
