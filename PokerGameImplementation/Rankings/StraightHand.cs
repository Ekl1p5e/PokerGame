using PokerGame.Interfaces;
using PokerGameImplementation.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PokerGameImplementation.UnitTests")]
namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand where cards are in sequential order, regardless of suit
    /// </summary>
    public class StraightHand : HandRanking
    {
        internal StraightHand(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.Straight;

        protected override int TieBreaker(HandRanking other)
        {
            var right = other as StraightHand;
            return Hand.CompareSequenceTo(right.Hand);
        }
    }
}
