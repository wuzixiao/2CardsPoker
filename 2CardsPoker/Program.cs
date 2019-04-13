using System;
using CardsPoker.Entities;
using CardsPoker.Services;

namespace CardsPoker
{
    class MainClass
    {
        public static int CardNumber = 2;
        public static int ShuffleTimes = 10;
        public static void Main(string[] args)
        {
            Console.WriteLine("Please input player number:");
            var playerNumber = Console.Read() - 48;
            if(playerNumber < 2 || playerNumber > 6)
            {
                Console.WriteLine("\nPlayer number is 2-6");
                playerNumber = Console.Read() - 48;
                if (playerNumber < 2 || playerNumber > 6)
                {
                    Console.WriteLine("\nGame over");
                    return;
                }

            }

            Console.WriteLine("\nPlease input round number:");
            var roundNumber = Console.Read() - 48;
            if (roundNumber < 2 || roundNumber>5)
            {
                Console.WriteLine("\nRound number is 2-5");
                roundNumber = Console.Read() - 48;
                if (roundNumber < 2 || roundNumber > 5)
                {
                    Console.WriteLine("\nGame over");
                    return;
                }
            }

            var service = new PokerService();

            var game = new Game(roundNumber, playerNumber, service);
            Console.WriteLine("\nGame Start!");
            game.Start();

            Console.WriteLine("Game over!");
        }
    }
}
