using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Data.Interfaces;
using project.Models;

namespace project.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly PlayersDbContext _context;
        
        public CatalogRepository(PlayersDbContext context)
        {
            _context = context;
        }
        
        public bool Add(Player player)
        {
            _context.Add(player);
            return Save();
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _context.Players.Include(i=>i.Team).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _context.Players.Include(p=>p.Team).ToListAsync();
        }
        
        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await _context.Teams.ToListAsync();
        }
        
        public bool Update(Player player)
        {
            _context.Update(player);
            return Save();
        }

        public bool Delete(Player player)
        {
            _context.Remove(player);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}