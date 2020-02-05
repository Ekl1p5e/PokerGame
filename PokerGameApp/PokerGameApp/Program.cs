using Poker.Interfaces;
using PokerGame.Interfaces;
using PokerGameImplementation;
using Unity;

namespace PokerGameApp
{
    class Program
    {
        /// <summary>
        /// This program determines the winner between two hands in poker.
        /// </summary>
        /// <param name="args">command line arguments</param>
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            //  Registrations
            container.RegisterSingleton<IHandRanker, PokerHandRanker>();
            container.RegisterSingleton<IPokerGame, BasicPokerGame>();
            //container.RegisterSingleton<ICardFactory<string>, PokerHandCodesConverter>();
            //container.RegisterType<IHandFactory, PokerHandFactory>();

            //  Resolve
            var pokerGame = container.Resolve<IPokerGame>();

            //  Prompt User
            //  Create hands from input

            //  Input into poker game
            //var result = pokerGame.GetResult(leftHand, rightHand);

            //  Output result
        }
    }
}
