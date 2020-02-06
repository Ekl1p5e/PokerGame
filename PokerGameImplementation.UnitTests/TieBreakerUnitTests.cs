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

            var left = new RoyalFlushHand(mockHand.Object);
            var right = new RoyalFlushHand(mockHand.Object);

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

            var left = new HighCardHand(mockLeft.Object);
            var right = new HighCardHand(mockRight.Object);

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

            var left = new ThreeOfAKindHand(mockLeft.Object);
            var right = new ThreeOfAKindHand(mockRight.Object);
            var lowerKicker = new ThreeOfAKindHand(mockLower.Object);

            Assert.Equal(1, left.CompareTo(right));
            Assert.Equal(1, left.CompareTo(lowerKicker));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, lowerKicker.CompareTo(left));
            Assert.Equal(-1, right.CompareTo(left));
        }

        [Fact]
        public void FullHouse_ReturnsAppropriateValue_TieBreaker()
        {
            var mockLeft = new Mock<IHand>();
            mockLeft.SetupGet(p => p.Cards).Returns(CardSequences.FullHouseHigherThreeKind);

            var mockRight = new Mock<IHand>();
            mockRight.SetupGet(p => p.Cards).Returns(CardSequences.FullHouseLowerThreeKind);

            var mockLower = new Mock<IHand>();
            mockLower.SetupGet(p => p.Cards).Returns(CardSequences.FullHouseLowerTwoKind);

            var left = new FullHouseHand(mockLeft.Object);
            var right = new FullHouseHand(mockRight.Object);
            var lowerKicker = new FullHouseHand(mockLower.Object);

            Assert.Equal(1, left.CompareTo(right));
            Assert.Equal(1, right.CompareTo(lowerKicker));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, lowerKicker.CompareTo(right));
            Assert.Equal(-1, right.CompareTo(left));
        }

        [Fact]
        public void OnePair_ReturnsAppropriateValue_TieBreaker()
        {
            var mockLeft = new Mock<IHand>();
            mockLeft.SetupGet(p => p.Cards).Returns(CardSequences.OnePairHigherSequence);

            var mockRight = new Mock<IHand>();
            mockRight.SetupGet(p => p.Cards).Returns(CardSequences.OnePairLower);

            var mockLower = new Mock<IHand>();
            mockLower.SetupGet(p => p.Cards).Returns(CardSequences.OnePairLowerSequence);

            var left = new OnePairHand(mockLeft.Object);
            var right = new OnePairHand(mockRight.Object);
            var lowerKicker = new OnePairHand(mockLower.Object);

            Assert.Equal(1, left.CompareTo(right));
            Assert.Equal(1, left.CompareTo(lowerKicker));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, lowerKicker.CompareTo(left));
            Assert.Equal(-1, right.CompareTo(left));
        }

        [Fact]
        public void Flush_ReturnsAppropriateValue_TieBreaker()
        {
            var mockLeft = new Mock<IHand>();
            mockLeft.SetupGet(p => p.Cards).Returns(CardSequences.DescendingHigher);

            var mockRight = new Mock<IHand>();
            mockRight.SetupGet(p => p.Cards).Returns(CardSequences.Descending);

            var left = new FlushHand(mockLeft.Object);
            var right = new FlushHand(mockRight.Object);

            Assert.Equal(1, left.CompareTo(right));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, right.CompareTo(left));
        }

        [Fact]
        public void StraightFlush_ReturnsAppropriateValue_TieBreaker()
        {
            var mockLeft = new Mock<IHand>();
            mockLeft.SetupGet(p => p.Cards).Returns(CardSequences.DescendingHigher);

            var mockRight = new Mock<IHand>();
            mockRight.SetupGet(p => p.Cards).Returns(CardSequences.Descending);

            var left = new StraightFlushHand(mockLeft.Object);
            var right = new StraightFlushHand(mockRight.Object);

            Assert.Equal(1, left.CompareTo(right));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, right.CompareTo(left));
        }

        [Fact]
        public void StraightHand_ReturnsAppropriateValue_TieBreaker()
        {
            var mockLeft = new Mock<IHand>();
            mockLeft.SetupGet(p => p.Cards).Returns(CardSequences.DescendingHigher);

            var mockRight = new Mock<IHand>();
            mockRight.SetupGet(p => p.Cards).Returns(CardSequences.Descending);

            var left = new StraightHand(mockLeft.Object);
            var right = new StraightHand(mockRight.Object);

            Assert.Equal(1, left.CompareTo(right));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, right.CompareTo(left));
        }

        [Fact]
        public void FourOfAKind_ReturnsAppropriateValue_TieBreaker()
        {
            var mockLeft = new Mock<IHand>();
            mockLeft.SetupGet(p => p.Cards).Returns(CardSequences.FourOfAKindHigher);

            var mockRight = new Mock<IHand>();
            mockRight.SetupGet(p => p.Cards).Returns(CardSequences.FourOfAKindLower);

            var mockLower = new Mock<IHand>();
            mockLower.SetupGet(p => p.Cards).Returns(CardSequences.FourOfAKindLowerKicker);

            var left = new FourOfAKindHand(mockLeft.Object);
            var right = new FourOfAKindHand(mockRight.Object);
            var lowerKicker = new FourOfAKindHand(mockLower.Object);

            Assert.Equal(1, left.CompareTo(right));
            Assert.Equal(1, left.CompareTo(lowerKicker));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, lowerKicker.CompareTo(left));
            Assert.Equal(-1, right.CompareTo(left));
        }

        [Fact]
        public void TwoPair_ReturnsAppropriateValue_TieBreaker()
        {
            var mockLeft = new Mock<IHand>();
            mockLeft.SetupGet(p => p.Cards).Returns(CardSequences.TwoPairHigher);

            var mockRight = new Mock<IHand>();
            mockRight.SetupGet(p => p.Cards).Returns(CardSequences.TwoPairLower);

            var mockLower = new Mock<IHand>();
            mockLower.SetupGet(p => p.Cards).Returns(CardSequences.TwoPairLowerKicker);

            var left = new TwoPairHand(mockLeft.Object);
            var right = new TwoPairHand(mockRight.Object);
            var lowerKicker = new TwoPairHand(mockLower.Object);

            Assert.Equal(1, left.CompareTo(lowerKicker));
            Assert.Equal(0, right.CompareTo(right));
            Assert.Equal(-1, lowerKicker.CompareTo(left));
        }
    }
}
