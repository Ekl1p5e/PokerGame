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
    }
}
