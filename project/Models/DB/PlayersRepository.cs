using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using project.Models.Interfaces;

namespace project.Models.DB
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly PlayersDbContext db;
        
        public PlayersRepository(PlayersDbContext db)
        {
            this.db = db;
        }
        //CRUD
        public void AddPlayer(PlayerModelView player)
        {
            try
            {
                db.Players.Add(player);
                db.SaveChanges();
            }
            catch (DbException e)
            {
                Console.WriteLine(e);
            }
        }

        public PlayerModelView GetPlayer(PlayerModelView player)
        {
            return db.Players.FirstOrDefault(p => p.PlayerId == player.PlayerId);
        }

        public IEnumerable<PlayerModelView> GetAllPlayers()
        {
            return db.Players.Select(p=>p).ToList();
        }
        
        public void UpdatePlayer(PlayerModelView player)
        {
            var found = GetPlayer(player);
            if (found == null) throw new Exception("Нет такого игрока");
            
            found.Name = player.Name;
            found.Surname = player.Surname;
            found.Sex = player.Sex;
            found.DateOfBirth = player.DateOfBirth;
            found.Team = player.Team;
            found.Country = player.Country;
            
            db.Entry(found).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
            }
        }
    }
}