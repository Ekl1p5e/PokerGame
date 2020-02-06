using PokerGame.Interfaces;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Interfaces;
using PokerGameImplementation.Rankings;
using System.Linq;

namespace PokerGameImplementation
{
    /// <summary>
    /// Class that implements logic to rank hands within a game
    /// </summary>
    public class PokerHandRanker : IHandRanker
    {
        /// <summary>
        /// Gets ranking for a hand
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <returns>Ranking of the hand</returns>
        public IHandRanking GetRanking(IHand hand)
        {
            if (hand.IsFlush())
            {
                if (hand.IsSequential())
                {
                    if (hand.HighestValue() == CardValue.Ace)
                    {
                        return new RoyalFlushHand(hand);
                    }

                    return new StraightFlushHand(hand);
                }

                return new FlushHand(hand);
            }

            var kinds = hand.GetKindsCount();
            if (kinds.Contains(4))
            {
                return new FourOfAKindHand(hand);
            }
            else if (kinds.Contains(3))
            {
                if (kinds.Contains(2))
                {
                    return new FullHouseHand(hand);
                }

                return new ThreeOfAKindHand(hand);
            }
            else if (kinds.Contains(2))
            {
                var pairCt = kinds.Count(kind => kind == 2);
                if (pairCt == 2)
                {
                    return new TwoPairHand(hand);
                }
                else if (pairCt == 1)
                {
                    return new OnePairHand(hand);
                }
            }

            if (hand.IsSequential())
            {
                return new StraightHand(hand);
            }

            return new HighCardHand(hand);
        }
    }
}
