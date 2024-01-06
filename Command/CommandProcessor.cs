using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace lab4
{
    class CommandProcessor
    {
        private readonly List<ICommand> commands = new List<ICommand>();

        public CommandProcessor()
        {
            // Ініціалізація команд
            IPlayerRepository playerRepository = new PlayerDbContext();
            IGameRepository gameRepository = new GameDbContext();
            IPlayerService playerService = new PlayerService(playerRepository);
            IGameService gameService = new GameService(gameRepository);

            commands.Add(new ShowPlayersCommand(playerService));
            commands.Add(new CreatePlayerCommand(playerService));
            commands.Add(new PlayGameCommand(gameService, playerService));
            commands.Add(new ShowPlayerStatsCommand(playerService));
        }

        public void ProcessCommands()
        {
            while (true)
            {
                Console.WriteLine("\nДоступні команди:");

                for (int i = 0; i < commands.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {commands[i].GetType().Name.Replace("Command", "")}");
                }

                Console.WriteLine("Введіть номер команди (або 'exit' для виходу):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (int.TryParse(input, out int choice) && choice > 0 && choice <= commands.Count)
                {
                    commands[choice - 1].Execute();
                }
                else
                {
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                }
            }
        }
    }
}
