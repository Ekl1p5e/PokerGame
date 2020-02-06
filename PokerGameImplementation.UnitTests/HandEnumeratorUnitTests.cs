using Moq;
using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace PokerGameImplementation.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class HandEnumeratorUnitTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_NullCards()
        {
            Assert.Throws<ArgumentNullException>(() => new HandEnumerator(null, default));
        }

        [Fact]
        public void GetEnumerator_ReturnsEmptyEnumerator_NoCards()
        {
            var list = new List<ICard>();

            var cards = new Mock<IEnumerable<ICard>>();
            cards.Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            var handEnumerator = new HandEnumerator(cards.Object, 0);

            var result = handEnumerator.GetEnumerator();

            Assert.False(result.MoveNext());
        }

        [Fact]
        public void GetEnumerator_ReturnsEnumerator_ProperConstructionInput()
        {
            var list = new List<ICard>();

            var cards = new Mock<IEnumerable<ICard>>();
            cards.Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            var handEnumerator = new HandEnumerator(cards.Object, 0);

            var result = handEnumerator.GetEnumerator();

            Assert.IsAssignableFrom<IEnumerator<IHand>>(result);
        }

        [Fact]
        public void GetEnumerator_ReturnsEnumeratorRemainder_CardsDoNotMakeUpWholeHand()
        {
            var list = new List<ICard>();

            var cards = new Mock<IEnumerable<ICard>>();
            cards.Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            var handEnumerator = new HandEnumerator(cards.Object, 0);

            var result = handEnumerator.GetEnumerator();

            Assert.False(result.MoveNext());
        }

        [Fact]
        public void GetEnumerator_DividesHandsProperly()
        {
            var handCardCount = 5;
            var cards = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Take(handCardCount * 2).Select(v => new Card(v, default));

            var handEnumerator = new HandEnumerator(cards, handCardCount);

            var first = handEnumerator.NextHand();
            var second = handEnumerator.NextHand();

            Assert.True(first.Cards.SequenceEqual(cards.Take(handCardCount)));
            Assert.True(second.Cards.SequenceEqual(cards.Skip(handCardCount).Take(handCardCount)));
        }
    }
}
