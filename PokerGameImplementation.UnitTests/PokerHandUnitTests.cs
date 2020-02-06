using Moq;
using PokerGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace PokerGameImplementation.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class PokerHandUnitTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new PokerHand(null));
        }

        [Fact]
        public void Constructor_SetsCardProperty_ArgumentNotNull()
        {
            var cards = new Mock<IEnumerable<ICard>>();
            var hand = new PokerHand(cards.Object);

            Assert.Same(cards.Object, hand.Cards);
        }
    }
}
