using Moq;
using PokerGame.Interfaces;
using PokerGameImplementation.Enums;
using PokerGameImplementation.Rankings;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
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
            //var otherHandRanking = new Mock<IHandRanking>();

            var mockHandRanking = new MockHandRanking(mockHand.Object);

            //Assert.Throws<ArgumentException>();
        }

        private class MockHandRanking : HandRanking
        {
            public MockHandRanking(IHand hand) : base(hand) { }

            protected override HandRank Rank => throw new NotImplementedException();

            protected override int TieBreaker(HandRanking other)
            {
                throw new NotImplementedException();
            }
        }
    }
}
