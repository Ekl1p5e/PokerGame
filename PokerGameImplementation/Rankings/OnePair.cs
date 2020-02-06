using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Enums;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PokerGameImplementation.UnitTests")]
namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that contains a single pair
    /// </summary>
    public class OnePair : HandRanking
    {
        private const int GROUP_NUMBER = 2;

        internal OnePair(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.OnePair;

        internal CardValue PairValue => Hand.GetFirstKindGroupCardValue(GROUP_NUMBER);

        internal IEnumerable<ICard> Kickers => Hand.GetKickers(Hand.GetFlattenedKindGroup(GROUP_NUMBER));

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as OnePair;
            if (PairValue > right.PairValue)
            {
                return 1;
            }
            else if (PairValue < right.PairValue)
            {
                return -1;
            }
            else
            {
                return Kickers.CompareSequenceTo(right.Kickers);
            }
        }
    }
}
