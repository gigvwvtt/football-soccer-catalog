using System.Collections.Generic;

namespace project.Models.Interfaces
{
    public interface IPlayersRepository
    {
        void AddPlayer(PlayerModelView player);
        PlayerModelView? GetPlayer(PlayerModelView player);
        IEnumerable<PlayerModelView> GetAllPlayers();
        void UpdatePlayer(PlayerModelView player);
    }
}