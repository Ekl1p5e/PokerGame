using PokerGame.Interfaces.Enums;
using System.Collections.Generic;

namespace PokerGameImplementation.UnitTests.Helpers
{
    public static class CardSequences
    {
        public static List<Card> Descending => new List<Card>
        {
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Six, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Four, CardSuit.Clubs),
            new Card(CardValue.Three, CardSuit.Clubs),
        };

        public static List<Card> DescendingHigher => new List<Card>
        {
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Six, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Four, CardSuit.Clubs),
        };

        public static List<Card> ThreeOfAKindHigher => new List<Card>
        {
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Four, CardSuit.Clubs),
        };

        public static List<Card> ThreeOfAKindLower => new List<Card>
        {
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Three, CardSuit.Clubs),
        };

        public static List<Card> ThreeOfAKindKickerLower => new List<Card>
        {
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Three, CardSuit.Clubs),
        };

        public static List<Card> FullHouseLowerTwoKind => new List<Card>
        {
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Four, CardSuit.Clubs),
            new Card(CardValue.Four, CardSuit.Clubs),
        };

        public static List<Card> FullHouseHigherThreeKind => new List<Card>
        {
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
        };

        public static List<Card> FullHouseLowerThreeKind => new List<Card>
        {
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
        };

        public static List<Card> OnePairLower => new List<Card>
        {
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Ace, CardSuit.Clubs),
            new Card(CardValue.King, CardSuit.Clubs),
            new Card(CardValue.Queen, CardSuit.Clubs),
        };

        public static List<Card> OnePairLowerSequence => new List<Card>
        {
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Six, CardSuit.Clubs),
        };

        public static List<Card> OnePairHigherSequence => new List<Card>
        {
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Jack, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
        };

        public static List<Card> FourOfAKindHigher => new List<Card>
        {
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
        };

        public static List<Card> FourOfAKindLower => new List<Card>
        {
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
        };

        public static List<Card> FourOfAKindLowerKicker => new List<Card>
        {
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Four, CardSuit.Clubs),
        };

        public static List<Card> TwoPairHigher => new List<Card>
        {
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Clubs),
        };

        public static List<Card> TwoPairLower => new List<Card>
        {
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Four, CardSuit.Clubs),
        };

        public static List<Card> TwoPairLowerKicker => new List<Card>
        {
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Four, CardSuit.Clubs),
        };
    }
}
