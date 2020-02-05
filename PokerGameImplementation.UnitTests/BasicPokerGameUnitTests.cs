using Moq;
using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using System;
using Xunit;

namespace PokerGameImplementation.UnitTests
{
    public class BasicPokerGameUnitTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_NullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new BasicPokerGame(null));
        }

        [Fact]
        public void GetResult_ThrowsArgumentNullException_NullLeftHandArgument()
        {
            var mockRanker = new Mock<IHandRanker>();

            var rightHand = new Mock<IHand>();

            var pokerGame = new BasicPokerGame(mockRanker.Object);

            Assert.Throws<ArgumentNullException>(() => pokerGame.GetResult(null, rightHand.Object));
        }

        [Fact]
        public void GetResult_ThrowsArgumentNullException_NullRightHandArgument()
        {
            var mockRanker = new Mock<IHandRanker>();

            var leftHand = new Mock<IHand>();

            var pokerGame = new BasicPokerGame(mockRanker.Object);

            Assert.Throws<ArgumentNullException>(() => pokerGame.GetResult(leftHand.Object, null));
        }

        [Fact]
        public void GetResult_ThrowsInvalidOperationException_RankerReturnsNullRanking()
        {
            var mockRanker = new Mock<IHandRanker>();

            var leftHand = new Mock<IHand>();
            var rightHand = new Mock<IHand>();

            var pokerGame = new BasicPokerGame(mockRanker.Object);

            Assert.Throws<InvalidOperationException>(() => pokerGame.GetResult(leftHand.Object, rightHand.Object));
        }

        [Fact]
        public void GetResult_RethrowsException_ThrownByRanker()
        {
            var exception = new Exception();

            var leftHand = new Mock<IHand>();
            var rightHand = new Mock<IHand>();

            var mockRanker = new Mock<IHandRanker>();
            mockRanker.Setup(m => m.GetRanking(It.IsAny<IHand>())).Throws(exception);

            var pokerGame = new BasicPokerGame(mockRanker.Object);

            var result = Assert.Throws<Exception>(() => pokerGame.GetResult(leftHand.Object, rightHand.Object));
            Assert.Same(exception, result);
        }

        [Fact]
        public void GetResult_RethrowsException_ThrownByComparison()
        {
            var exception = new Exception();

            var leftHand = new Mock<IHand>();

            var rightHand = new Mock<IHand>();

            var rightHandRanking = new Mock<IHandRanking>();

            var leftHandRanking = new Mock<IHandRanking>();
            leftHandRanking.Setup(m => m.CompareTo(It.IsAny<IHandRanking>())).Throws(exception);

            var mockRanker = new Mock<IHandRanker>();
            mockRanker.Setup(m => m.GetRanking(leftHand.Object)).Returns(leftHandRanking.Object);
            mockRanker.Setup(m => m.GetRanking(rightHand.Object)).Returns(rightHandRanking.Object);

            var pokerGame = new BasicPokerGame(mockRanker.Object);

            var result = Assert.Throws(exception.GetType(), () => pokerGame.GetResult(leftHand.Object, rightHand.Object));
            Assert.Same(exception, result);
        }

        [Theory]
        [InlineData(-1, GameResult.RightHandWinner)]
        [InlineData(0, GameResult.Draw)]
        [InlineData(1, GameResult.LeftHandWinner)]
        public void GetResult_ReturnsCorrectResult_Comparison(int comparisonResult, GameResult gameResult)
        {
            var leftHand = new Mock<IHand>();

            var rightHand = new Mock<IHand>();

            var rightHandRanking = new Mock<IHandRanking>();

            var leftHandRanking = new Mock<IHandRanking>();
            leftHandRanking.Setup(m => m.CompareTo(It.IsAny<IHandRanking>())).Returns(comparisonResult);

            var mockRanker = new Mock<IHandRanker>();
            mockRanker.Setup(m => m.GetRanking(leftHand.Object)).Returns(leftHandRanking.Object);
            mockRanker.Setup(m => m.GetRanking(rightHand.Object)).Returns(rightHandRanking.Object);

            var pokerGame = new BasicPokerGame(mockRanker.Object);

            var result = pokerGame.GetResult(leftHand.Object, rightHand.Object);

            Assert.Equal(gameResult, result);
        }
    }
}
