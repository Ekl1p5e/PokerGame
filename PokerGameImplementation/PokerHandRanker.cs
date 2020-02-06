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
                        return new RoyalFlush(hand);
                    }

                    return new StraightFlush(hand);
                }

                return new Flush(hand);
            }

            var kinds = hand.GetKindsCount();
            if (kinds.Contains(4))
            {
                return new FourOfAKind(hand);
            }
            else if (kinds.Contains(3))
            {
                if (kinds.Contains(2))
                {
                    return new FullHouse(hand);
                }

                return new ThreeOfAKind(hand);
            }
            else if (kinds.Contains(2))
            {
                var pairCt = kinds.Count(kind => kind == 2);
                if (pairCt == 2)
                {
                    return new TwoPair(hand);
                }
                else if (pairCt == 1)
                {
                    return new OnePair(hand);
                }
            }

            if (hand.IsSequential())
            {
                return new Straight(hand);
            }

            return new HighCard(hand);
        }
    }
}
