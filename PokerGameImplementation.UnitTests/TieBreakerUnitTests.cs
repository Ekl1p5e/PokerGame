using Moq;
using PokerGame.Interfaces;
using PokerGameImplementation.Rankings;
using PokerGameImplementation.UnitTests.Helpers;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace PokerGameImplementation.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class TieBreakerUnitTests
    {
        [Fact]
        public void RoyalFlush_ReturnsZero_TieBreaker()
        {
            var mockHand = new Mock<IHand>();

            var left = new RoyalFlush(mockHand.Object);
            var right = new RoyalFlush(mockHand.Object);

            Assert.Equal(0, left.CompareTo(right));
            Assert.Equal(0, right.CompareTo(left));
        }

        [Fact]
        public void HighCard_ReturnsAppropriateValue_TieBreaker()
        {
            var mockLeft = new Mock<IHand>();
            mockLeft.SetupGet(p => p.Cards).Returns(CardSequences.DescendingHigher);

            var mockRight = new Mock<IHand>();
            mockRight.SetupGet(p => p.Cards).Returns(CardSequences.Descending);

            var left = new HighCard(mockLeft.Object);
            var right = new HighCard(mockRight.Object);

            Assert.Equal(1, left.CompareTo(right));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, right.CompareTo(left));
        }

        [Fact]
        public void ThreeOfAKind_ReturnsAppropriateValue_TieBreaker()
        {
            var mockLeft = new Mock<IHand>();
            mockLeft.SetupGet(p => p.Cards).Returns(CardSequences.ThreeOfAKindHigher);

            var mockRight = new Mock<IHand>();
            mockRight.SetupGet(p => p.Cards).Returns(CardSequences.ThreeOfAKindLower);

            var mockLower = new Mock<IHand>();
            mockLower.SetupGet(p => p.Cards).Returns(CardSequences.ThreeOfAKindKickerLower);

            var left = new ThreeOfAKind(mockLeft.Object);
            var right = new ThreeOfAKind(mockRight.Object);
            var lowerKicker = new ThreeOfAKind(mockLower.Object);

            Assert.Equal(1, left.CompareTo(right));
            Assert.Equal(1, left.CompareTo(lowerKicker));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, right.CompareTo(left));
            Assert.Equal(-1, lowerKicker.CompareTo(left));
        }
    }
}
