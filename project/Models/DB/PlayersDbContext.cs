using Microsoft.EntityFrameworkCore;

namespace project.Models.DB
{
    public class PlayersDbContext : DbContext
    {
        public PlayersDbContext(DbContextOptions<PlayersDbContext> options) : base(options)
        {
        }
        
        public DbSet<PlayerModelView> Players { get; set; }

    }
}