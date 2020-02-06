using Moq;
using PokerGame.Interfaces;
using PokerGameImplementation.Enums;
using PokerGameImplementation.Interfaces;
using PokerGameImplementation.Rankings;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace PokerGameImplementation.UnitTests.RankingTests
{
    [ExcludeFromCodeCoverage]
    public class HandRankingUnitTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_NullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new MockHandRanking(null));
        }

        [Fact]
        public void CompareTo_ArgumentNotHandRankingClass_ThrowsException()
        {
            var mockHand = new Mock<IHand>();
            var otherHandRanking = new Mock<IHandRanking>();

            var mockHandRanking = new MockHandRanking(mockHand.Object);

            Assert.Throws<ArgumentException>(() => mockHandRanking.CompareTo(otherHandRanking.Object));
        }

        [Fact]
        public void CompareTo_ReturnsNegativeOne_ClassComparedToGreater()
        {
            var mockHand = new Mock<IHand>();

            var otherHandRanking = new MockHandRanking(mockHand.Object, HandRank.RoyalFlush);
            var mockHandRanking = new MockHandRanking(mockHand.Object, HandRank.HighCard);

            Assert.Equal(-1, mockHandRanking.CompareTo(otherHandRanking));
        }

        [Fact]
        public void CompareTo_ReturnsOne_ClassComparedToLesser()
        {
            var mockHand = new Mock<IHand>();

            var otherHandRanking = new MockHandRanking(mockHand.Object, HandRank.HighCard);
            var mockHandRanking = new MockHandRanking(mockHand.Object, HandRank.RoyalFlush);

            Assert.Equal(1, mockHandRanking.CompareTo(otherHandRanking));
        }

        private class MockHandRanking : HandRanking
        {
            public MockHandRanking(IHand hand, HandRank rank = default) : base(hand)
            {
                Rank = rank;
            }

            protected override HandRank Rank { get; }

            protected override int TieBreaker(HandRanking other)
            {
                throw new NotImplementedException();
            }
        }
    }
}
