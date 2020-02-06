using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;

namespace PokerGameImplementation
{
    public class Card : ICard
    {
        public Card(CardValue cardValue, CardSuit cardSuit)
        {
            Suit = cardSuit;
            Value = cardValue;
        }

        public CardSuit Suit { get; }

        public CardValue Value { get; }
    }
}
