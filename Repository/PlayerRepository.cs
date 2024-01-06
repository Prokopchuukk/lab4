using System;
using System.Collections.Generic;

namespace lab4
{

    interface IPlayerRepository
    {
        void CreatePlayer(GameAccount player);
        GameAccount ReadPlayerById(string playerId);
        List<GameAccount> ReadAllPlayers(); 
        void UpdatePlayer(GameAccount player);
        void DeletePlayer(string playerId);
    }

    class PlayerRepository : IPlayerRepository
    {
        private readonly List<GameAccount> players = new List<GameAccount>();

        public void CreatePlayer(GameAccount player) => players.Add(player);
        public GameAccount ReadPlayerById(string playerId) => players.Find(player => player.UserName == playerId);
        public List<GameAccount> ReadAllPlayers() => players; 
        public void UpdatePlayer(GameAccount player) => players[players.FindIndex(p => p.UserName == player.UserName)] = player;
        public void DeletePlayer(string playerId) => players.RemoveAll(p => p.UserName == playerId);
    }
}
