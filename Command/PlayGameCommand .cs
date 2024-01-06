using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace lab4
{
    class PlayGameCommand : ICommand
    {
        private readonly IGameService gameService;
        private readonly IPlayerService playerService;

        public PlayGameCommand(IGameService gameService, IPlayerService playerService)
        {
            this.gameService = gameService;
            this.playerService = playerService;
        }

        public void Execute()
        {
            Console.WriteLine("Виберіть гравців для гри:");
            Console.Write("Ім'я першого гравця: ");
            string player1Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(player1Name))
            {
                Console.WriteLine("Ім'я першого гравця не може бути порожнім.");
                return;
            }

            Console.Write("Ім'я другого гравця: ");
            string player2Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(player2Name))
            {
                Console.WriteLine("Ім'я другого гравця не може бути порожнім.");
                return;
            }

            Console.Write("Виберіть тип гри (Standard/ReducedPenalty/Training): ");
            string gameType = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(gameType))
            {
                Console.WriteLine("Тип гри не може бути порожнім.");
                return;
            }

            GameAccount player1 = playerService.GetPlayerById(player1Name);
            GameAccount player2 = playerService.GetPlayerById(player2Name);

            if (player1 != null && player2 != null)
            {
                Game newGame = GameFactory.CreateGame(player1, player2, gameType);
                gameService.CreateGame(newGame);

                // Ось де ми модифікуємо рейтинги гравців на основі результатів гри
                if (newGame.Player1Wins)
                {
                    player1.WinGame(newGame, player2);
                    player2.LoseGame(newGame, player1);
                }
                else
                {
                    player1.LoseGame(newGame, player2);
                    player2.WinGame(newGame, player1);
                }

                Console.WriteLine($"Гра між {player1.UserName} та {player2.UserName} створена.");
            }
            else
            {
                Console.WriteLine("Гравеці не знайдені.");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Команда для гри.");
        }
    }

}
