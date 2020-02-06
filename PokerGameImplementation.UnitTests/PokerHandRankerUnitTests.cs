using Moq;
using PokerGame.Interfaces;
using PokerGameImplementation.Rankings;
using PokerGameImplementation.UnitTests.Helpers;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace PokerGameImplementation.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class PokerHandRankerUnitTests
    {
        [Fact]
        public void GetRanking_IsFlushAndNotSequential_ReturnsFlushType()
        {
            var hand = new Mock<IHand>().
                IsFlush().
                IsNotSequential();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<Flush>(ranking);
        }

        [Fact]
        public void GetRanking_IsFlushAndSequentialWithoutHighAce_ReturnsStraightFlushType()
        {
            var hand = new Mock<IHand>().
                IsFlush().
                IsSequential().
                NotAceHigh();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<StraightFlush>(ranking);
        }

        [Fact]
        public void GetRanking_IsFlushAndSequentialWithHighAce_ReturnsRoyalFlushType()
        {
            var hand = new Mock<IHand>().
                IsFlush().
                IsSequential().
                AceHigh();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<RoyalFlush>(ranking);
        }

        [Fact]
        public void GetRanking_FourCardsOfAKind_ReturnsFourOfAKindType()
        {
            var hand = new Mock<IHand>().FourOfAKind();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<FourOfAKind>(ranking);
        }

        [Fact]
        public void GetRanking_ThreeCardsOfAKindNoFullHouse_ReturnsThreeOfAKindType()
        {
            var hand = new Mock<IHand>().ThreeOfAKind();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<ThreeOfAKind>(ranking);
        }

        [Fact]
        public void GetRanking_ThreeCardsOfAKindAndTwoCardsOfAKind_ReturnsFullHouseType()
        {
            var hand = new Mock<IHand>().FullHouse();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<FullHouse>(ranking);
        }

        [Fact]
        public void GetRanking_TwoPairs_ReturnsTwoPairType()
        {
            var hand = new Mock<IHand>().TwoPair();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<TwoPair>(ranking);
        }

        [Fact]
        public void GetRanking_OnePair_ReturnsOnePairType()
        {
            var hand = new Mock<IHand>().OnePair();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<OnePair>(ranking);
        }

        [Fact]
        public void GetRanking_IsNotFlushAndIsSequential_ReturnsStraightType()
        {
            var hand = new Mock<IHand>().
                IsNotFlush().
                IsSequential();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<Straight>(ranking);
        }

        [Fact]
        public void GetRanking_IsNotFlushOrSequentialOrOfAKind_ReturnsHighCard()
        {
            var hand = new Mock<IHand>().
                IsNotFlush().
                IsNotSequential().
                NotAKind();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<HighCard>(ranking);
        }
    }
}
