using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace lab4
{
    class CreatePlayerCommand : ICommand
    {
        private readonly IPlayerService playerService;

        public CreatePlayerCommand(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public void Execute()
        {
            Console.Write("Введіть ім'я нового гравця: ");
            string playerName = Console.ReadLine();
            Console.Write("Виберіть тип гравця (Standard/ReducedPenalty/Training): ");
            string playerType = Console.ReadLine();

            GameAccount newPlayer = GameFactory.CreateGameAccount(playerName, playerType);
            playerService.CreateAccount(newPlayer);

            Console.WriteLine($"Гравець {newPlayer.UserName} створений.");
        }

        public void ShowInfo()
        {
            Console.WriteLine("Команда для створення нового гравця.");
        }
    }
}
