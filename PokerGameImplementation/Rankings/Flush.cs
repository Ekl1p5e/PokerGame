using PokerGame.Interfaces;
using PokerGameImplementation.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PokerGameImplementation.UnitTests")]
namespace PokerGameImplementation.Rankings
{
    /// <summary>
    /// Class representing a hand that has all cards of the same suit
    /// </summary>
    public class Flush : HandRanking
    {
        internal Flush(IHand hand) : base(hand) { }

        protected override HandRank Rank => HandRank.Flush;

        protected override int TieBreaker(HandRanking other)
        {
            return Hand.CompareSequenceTo(other.Hand);
        }
    }
}
