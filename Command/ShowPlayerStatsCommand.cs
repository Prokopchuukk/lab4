using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace lab4
{
    class ShowPlayerStatsCommand : ICommand
    {
        private readonly IPlayerService playerService;

        public ShowPlayerStatsCommand(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public void Execute()
        {
            Console.Write("Введіть ім’я або ІД гравця: ");
            string playerId = Console.ReadLine();

            GameAccount player = playerService.GetPlayerById(playerId);

            if (player != null)
            {
                player.GetStats(playerService);
            }
            else
            {
                Console.WriteLine("Гравець не знайдений.");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Команда для виведення статистики конкретного гравця.");
        }
    }
}
