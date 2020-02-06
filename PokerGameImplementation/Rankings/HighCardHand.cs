using PokerGame.Interfaces;
using PokerGameImplementation.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PokerGameImplementation.UnitTests")]
namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand where the high card is significant
    /// </summary>
    public class HighCardHand : HandRanking
    {
        internal HighCardHand(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.HighCard;

        protected override int TieBreaker(HandRanking other)
        {
            return Hand.CompareSequenceTo(other.Hand);
        }
    }
}
