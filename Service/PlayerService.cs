using System;
using System.Collections.Generic;

namespace lab4
{

    interface IPlayerService
    {
        void CreateAccount(GameAccount player);
        GameAccount GetPlayerById(string playerId);
        List<GameAccount> GetAllPlayers();  
        void UpdateAccount(GameAccount player);
        void DeleteAccount(string playerId);
    }


    class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository repository;

        public PlayerService(IPlayerRepository repository) => this.repository = repository;

        public void CreateAccount(GameAccount player) => repository.CreatePlayer(player);
        public GameAccount GetPlayerById(string playerId) => repository.ReadPlayerById(playerId);
        public List<GameAccount> GetAllPlayers() => repository.ReadAllPlayers();  
        public void UpdateAccount(GameAccount player) => repository.UpdatePlayer(player);
        public void DeleteAccount(string playerId) => repository.DeletePlayer(playerId);
    }

}
