using System.Collections.Generic;
using System.Threading.Tasks;
using project.Models;

namespace project.Data.Interfaces
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<IEnumerable<Team>> GetAllTeams();
        Task<Player> GetPlayerByIdAsync(int id);
        bool Add(Player player);
        bool Update(Player player);
        bool Delete(Player player);
        bool Save();
    }
}