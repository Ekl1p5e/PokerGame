using PokerGame.Interfaces;
using PokerGameImplementation.Rankings.Enums;

namespace PokerGameImplementation.Rankings
{
    public class Straight : HandRanking
    {
        internal Straight(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.Straight;

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as Straight;
            return Hand.IsGreaterSequence(right.Hand);
        }
    }
}
