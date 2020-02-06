﻿using Poker.Interfaces;
using PokerGame.Interfaces;
using PokerGameImplementation;
using PokerGameImplementation.Interfaces;
using System;
using Unity;
using Unity.Injection;

namespace PokerGameApp
{
    class Program
    {
        private const int HAND_CARDS_COUNT = 5;
        private const int CONSOLE_INPUT_COUNT = 10;

        private readonly static UnityContainer _container = new UnityContainer();

        /// <summary>
        /// This program determines the winner between two hands in poker.
        /// </summary>
        /// <param name="args">command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                RegisterPokerGameClasses();

                //  Resolve
                var pokerGame = _container.Resolve<IPokerGame>();
                var handIterator = _container.Resolve<IHandEnumerator>();
                var gameOutput = _container.Resolve<IGameOutput>();

                //  Get hands
                var leftHand = handIterator.NextHand();
                var rightHand = handIterator.NextHand();

                //  Input hands into poker game
                var result = pokerGame.GetResult(leftHand, rightHand);

                //  Output game result
                gameOutput.Output(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void RegisterPokerGameClasses()
        {
            //  Registrations
            _container.RegisterSingleton<IHandRanker, PokerHandRanker>();
            _container.RegisterSingleton<IPokerGame, BasicPokerGame>();
            _container.RegisterSingleton<ICardEnumerator, ConsoleCodeInput>(new InjectionConstructor(typeof(ICodeConverter), CONSOLE_INPUT_COUNT));
            _container.RegisterSingleton<IHandEnumerator, HandEnumerator>(new InjectionConstructor(typeof(ICardEnumerator), HAND_CARDS_COUNT));
            _container.RegisterSingleton<ICodeConverter, PokerHandCodesConverter>();
            _container.RegisterSingleton<IGameOutput, PokerGameOutput>();
        }
    }
}
