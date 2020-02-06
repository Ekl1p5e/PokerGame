using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameImplementation
{
    /// <summary>
    /// Extension methods for implementation classes
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Compares a sequence to determine if greater, lesser, or the same
        /// </summary>
        /// <remarks>
        /// Sequence is sorted descending and compared pairwise
        /// </remarks>
        /// <param name="left">Binding variable of left sequence</param>
        /// <param name="right">Sequence to compare</param>
        /// <returns>
        /// -1 if left is less than right
        /// 0 if left and right are sequence equal
        /// 1 if left is greater than right
        /// </returns>
        internal static int CompareSequenceTo(this IEnumerable<ICard> left, IEnumerable<ICard> right)
        {
            var orderedLeft = left.OrderByDescending(card => card.Value);
            var orderedRight = right.OrderByDescending(card => card.Value);

            if (orderedLeft.Zip(orderedRight, (l, r) => new { left = l, right = r }).
                FirstOrDefault(z => z.left.Value != z.right.Value) is var result)
            {
                return result.left.Value > result.right.Value ? 1 : -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Compares hands to determine if greater, lesser, or the same
        /// </summary>
        /// <remarks>
        /// Internally uses the overloaded <see cref="CompareSequenceTo(IEnumerable{ICard}, IEnumerable{ICard})"/> method
        /// </remarks>
        /// <param name="left">Binding variable of left sequence</param>
        /// <param name="right">Sequence to compare</param>
        /// <returns>
        /// -1 if left is less than right
        /// 0 if left and right are sequence equal
        /// 1 if left is greater than right
        /// </returns>
        internal static int CompareSequenceTo(this IHand left, IHand right)
        {
            return left.Cards.CompareSequenceTo(right.Cards);
        }

        /// <summary>
        /// Groups cards by kinds that match the count
        /// </summary>
        /// <param name="hand">Binding variable</param>
        /// <param name="count">Count of kinds</param>
        /// <returns>An enumerable of enumerable groups of cards of requested count</returns>
        internal static IEnumerable<IGrouping<CardValue, ICard>> GetKindGroup(this IHand hand, int count)
        {
            return hand.Cards.
                GroupBy(card => card.Value).
                Where(group => group.Count() == count);
        }

        /// <summary>
        /// Gets leftover cards in a hand
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <param name="exclude">Group of cards to exclude</param>
        /// <returns>Kicker cards</returns>
        internal static IEnumerable<ICard> GetKickers(this IHand hand, IEnumerable<ICard> exclude)
        {
            return hand.Cards.Except(exclude);
        }

        /// <summary>
        /// Determines if hand is straight, or all cards of the same suit
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <returns>A value indicating whether or not the hand is straight or not</returns>
        internal static bool IsFlush(this IHand hand)
        {
            return hand.Cards.Select(card => card.Suit).Distinct().Count() == 1;
        }

        /// <summary>
        /// Determines if the hand has values in contiguous sequential order
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <returns>A value indicating whether or not the hand is in contiguous sequential order or not</returns>
        internal static bool IsSequential(this IHand hand)
        {
            var orderedCards = hand.Cards.OrderBy(card => card.Value).Select(card => card.Value);

            var firstCard = orderedCards.First();
            var values = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().
                SkipWhile(value => value != firstCard).
                Take(orderedCards.Count());

            return orderedCards.Zip(values, (first, second) => first == second).All(value => value);
        }

        /// <summary>
        /// Gets highest value of a hand
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <returns>Highest card value of the hand</returns>
        internal static CardValue HighestValue(this IHand hand)
        {
            return hand.Cards.Max(card => card.Value);
        }

        /// <summary>
        /// Gets an array of counts for each kind of value
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <returns>Array of counts</returns>
        internal static int[] GetKindsCount(this IHand hand) => hand.Cards.GroupBy(card => card.Value).Select(group => group.Count()).ToArray();

        /// <summary>
        /// Gets the value of the first grouping
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <param name="count">Count per grouping</param>
        /// <returns>value of the first card grouping</returns>
        internal static CardValue GetFirstKindGroupCardValue(this IHand hand, int count)
        {
            return hand.GetKindGroup(count).First().Key;
        }

        /// <summary>
        /// Flattens card groupings
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <param name="count">Count per grouping</param>
        /// <returns>enumerable of cards from grouping</returns>
        internal static IEnumerable<ICard> GetFlattenedKindGroup(this IHand hand, int count)
        {
            return hand.GetKindGroup(count).SelectMany(group => group.ToList());
        }
    }
}
