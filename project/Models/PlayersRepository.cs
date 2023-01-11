using Microsoft.EntityFrameworkCore;

namespace project.Models
{
    public class PlayersRepository : DbContext
    {
        public PlayersRepository() : base()
        {
            
        }
        
        public DbSet<PlayerModelView> Players { get; set; }
    }
}