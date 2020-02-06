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
        public void GetRanking_FlushHand_ReturnsFlushType()
        {
            var hand = new Mock<IHand>().FlushHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<Flush>(ranking);
        }

        [Fact]
        public void GetRanking_StraightFlushHand_ReturnsStraightFlushType()
        {
            var hand = new Mock<IHand>().StraightFlushHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<StraightFlush>(ranking);
        }

        [Fact]
        public void GetRanking_RoyalFlushHand_ReturnsRoyalFlushType()
        {
            var hand = new Mock<IHand>().RoyalFlushHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<RoyalFlush>(ranking);
        }

        [Fact]
        public void GetRanking_FourOfAKindHand_ReturnsFourOfAKindType()
        {
            var hand = new Mock<IHand>().FourOfAKindHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<FourOfAKind>(ranking);
        }

        [Fact]
        public void GetRanking_ThreeOfAKindHand_ReturnsThreeOfAKindType()
        {
            var hand = new Mock<IHand>().ThreeOfAKindHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<ThreeOfAKind>(ranking);
        }

        [Fact]
        public void GetRanking_FullHouseHand_ReturnsFullHouseType()
        {
            var hand = new Mock<IHand>().FullHouseHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<FullHouse>(ranking);
        }

        [Fact]
        public void GetRanking_TwoPairsHand_ReturnsTwoPairType()
        {
            var hand = new Mock<IHand>().TwoPairHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<TwoPair>(ranking);
        }

        [Fact]
        public void GetRanking_OnePairHand_ReturnsOnePairType()
        {
            var hand = new Mock<IHand>().OnePairHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<OnePair>(ranking);
        }

        [Fact]
        public void GetRanking_StraightHand_ReturnsStraightType()
        {
            var hand = new Mock<IHand>().StraightHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<StraightHand>(ranking);
        }

        [Fact]
        public void GetRanking_HighCardHand_ReturnsHighCard()
        {
            var hand = new Mock<IHand>().HighCardHandRank();

            var ranker = new PokerHandRanker();

            var ranking = ranker.GetRanking(hand.Object);

            Assert.IsType<HighCard>(ranking);
        }
    }
}
