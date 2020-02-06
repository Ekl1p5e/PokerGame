using Moq;
using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PokerGameImplementation.UnitTests.Helpers
{
    [ExcludeFromCodeCoverage]
    internal static class Extensions
    {
        internal static Mock<IHand> FourOfAKindHandRank(this Mock<IHand> hand, CardValue value = default)
        {
            var kinds = new List<Card>(Enum.GetValues(typeof(CardSuit)).
                Cast<CardSuit>().
                Take(4).
                Select(suit => new Card(value, suit)));
            var kicker = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Except(new[] { value }).Select(cardValue => new Card(cardValue, default)).First();
            kinds.Add(kicker);

            hand.SetupGet(p => p.Cards).Returns(kinds);

            return hand;
        }

        internal static Mock<IHand> ThreeOfAKindHandRank(this Mock<IHand> hand, CardValue value = default)
        {
            var kinds = GetListOfCardsByKindCount(value, 3);
            kinds.AddKickers();

            hand.SetupGet(p => p.Cards).Returns(kinds);

            return hand;
        }

        internal static Mock<IHand> FullHouseHandRank(this Mock<IHand> hand)
        {
            var values = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Take(2);

            var threeKind = GetListOfCardsByKindCount(values.First(), 3);
            var twoKind = GetListOfCardsByKindCount(values.Last(), 2);

            hand.SetupGet(p => p.Cards).Returns(threeKind.Concat(twoKind));

            return hand;
        }

        internal static Mock<IHand> TwoPairHandRank(this Mock<IHand> hand)
        {
            var values = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Take(2);

            var firstPair = GetListOfCardsByKindCount(values.First(), 2);
            var secondPair = GetListOfCardsByKindCount(values.Last(), 2);

            var cards = firstPair.Concat(secondPair).AddKickers();

            hand.SetupGet(p => p.Cards).Returns(cards);

            return hand;
        }

        internal static Mock<IHand> OnePairHandRank(this Mock<IHand> hand)
        {
            var twoKind = GetListOfCardsByKindCount(default, 2);

            var cards = twoKind.AddKickers();

            hand.SetupGet(p => p.Cards).Returns(cards);

            return hand;
        }

        internal static Mock<IHand> FlushHandRank(this Mock<IHand> hand)
        {
            return hand.IsFlush().
                IsNotSequential();
        }

        internal static Mock<IHand> RoyalFlushHandRank(this Mock<IHand> hand)
        {
            return hand.IsFlush().
                IsSequential().
                AceHigh();
        }

        internal static Mock<IHand> StraightHandRank(this Mock<IHand> hand)
        {
            return hand.IsNotFlush().
                IsSequential();
        }

        internal static Mock<IHand> StraightFlushHandRank(this Mock<IHand> hand)
        {
            return hand.IsFlush().
                IsSequential().
                NotAceHigh();
        }

        internal static Mock<IHand> HighCardHandRank(this Mock<IHand> hand)
        {
            return hand.IsNotFlush().
                IsNotSequential().
                NotAKind();
        }

        private static Mock<IHand> IsFlush(this Mock<IHand> hand, CardSuit suit = default)
        {
            var cards = hand.Object.Cards;
            if (cards.Count() < 5)
            {
                cards = Enumerable.Range(0, 5).Select(_ => new Card(default, suit));
            }

            var seqValues = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Take(5);

            var newValues = cards.Zip(seqValues, (card, value) => new Card(value, card.Suit));

            hand.SetupGet(p => p.Cards).Returns(newValues);

            return hand;
        }

        private static Mock<IHand> IsNotFlush(this Mock<IHand> hand)
        {
            var cards = hand.Object.Cards;
            if (cards.Count() < 5)
            {
                cards = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>().Select(suit => new Card(default, suit));
            }

            var distinctValues = cards.Select(card => card.Value).Distinct();
            if (distinctValues.Count() < 2)
            {
                var swapValue = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Except(distinctValues).First();

                var card = cards.Last();

                var newCards = cards.Take(4).Concat(new[] { new Card(swapValue, card.Suit) });
                hand.SetupGet(p => p.Cards).Returns(newCards);
            }
            else
            {
                hand.SetupGet(p => p.Cards).Returns(cards);
            }

            return hand;
        }

        private static Mock<IHand> IsNotSequential(this Mock<IHand> hand)
        {
            var cards = hand.Object.Cards;
            if (cards.Count() < 5)
            {
                cards = Enumerable.Range(0, 5).Select(_ => new Card(default, default));
            }

            var seqValues = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Take(6);
            var nonSeqValues = seqValues.Except(new[] { seqValues.ElementAt(2) });

            var newValues = cards.Zip(nonSeqValues, (card, value) => new Card(value, card.Suit));

            hand.SetupGet(p => p.Cards).Returns(newValues);

            return hand;
        }

        private static Mock<IHand> IsSequential(this Mock<IHand> hand)
        {
            var cards = hand.Object.Cards;
            if (cards.Count() < 5)
            {
                cards = Enumerable.Range(0, 5).Select(_ => new Card(default, default));
            }

            var seqValues = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Take(5);

            var newValues = cards.Zip(seqValues, (card, value) => new Card(value, card.Suit));

            hand.SetupGet(p => p.Cards).Returns(newValues);

            return hand;
        }

        private static Mock<IHand> NotAceHigh(this Mock<IHand> hand)
        {
            var cards = hand.Object.Cards;
            if (cards.Count() < 5)
            {
                cards = Enumerable.Range(0, 5).Select(_ => new Card(default, default));
            }

            var aces = cards.Where(card => card.Value == CardValue.Ace);
            if (aces.Any())
            {
                var newCards = cards.Select(card => new Card(card.Value - 1, card.Suit));

                hand.SetupGet(p => p.Cards).Returns(newCards);
            }
            else
            {
                hand.SetupGet(p => p.Cards).Returns(cards);
            }

            return hand;
        }

        private static Mock<IHand> AceHigh(this Mock<IHand> hand)
        {
            var cards = hand.Object.Cards;
            if (cards.Count() < 5)
            {
                cards = Enumerable.Range(0, 5).Select(_ => new Card(default, default));
            }

            var aces = cards.Where(card => card.Value == CardValue.Ace);
            if (!aces.Any())
            {
                var difference = CardValue.Ace - cards.OrderByDescending(card => card.Value).First().Value;

                var newCards = cards.Select(card => new Card(card.Value + difference, card.Suit));

                hand.SetupGet(p => p.Cards).Returns(newCards);
            }
            else
            {
                hand.SetupGet(p => p.Cards).Returns(cards);
            }

            return hand;
        }

        private static Mock<IHand> NotAKind(this Mock<IHand> hand)
        {
            var cards = hand.Object.Cards;
            if (cards.Count() < 5)
            {
                cards = Enumerable.Range(0, 5).Select(_ => new Card(default, default));
            }

            var seqValues = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().Where((value, index) => index % 2 == 0).Take(5);

            var newValues = cards.Zip(seqValues, (card, value) => new Card(value, card.Suit));

            hand.SetupGet(p => p.Cards).Returns(newValues);

            return hand;

        }

        private static List<Card> GetListOfCardsByKindCount(CardValue value, int count)
        {
            return new List<Card>(Enum.GetValues(typeof(CardSuit)).
                Cast<CardSuit>().
                Take(count).
                Select(suit => new Card(value, suit)));
        }

        private static IEnumerable<Card> AddKickers(this IEnumerable<Card> cards)
        {
            var kickers = Enum.GetValues(typeof(CardValue)).
                Cast<CardValue>().
                Except(cards.Select(card => card.Value).Distinct()).
                Take(5 - cards.Count()).
                Select(cardValue => new Card(cardValue, default));

            return cards.Concat(kickers);
        }
    }
}
