using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace lab4
{
    class ShowPlayersCommand : ICommand
    {
        private readonly IPlayerService playerService;

        public ShowPlayersCommand(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public void Execute()
        {
            // Логіка виведення гравців
            Console.WriteLine("Список гравців:");
            var players = playerService.GetAllPlayers();
            foreach (var player in players)
            {
                Console.WriteLine($"Ім'я: {player.UserName}, Тип: {player.GetType().Name}, Рейтинг: {player.CurrentRating}");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Команда для виведення списку гравців.");
        }
    }
}
