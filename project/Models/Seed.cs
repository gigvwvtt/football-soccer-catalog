using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using project.Data;
using project.Data.Enums;

namespace project.Models
{
    public static class Seed
    {
        public static void PopulateData(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PlayersDbContext>();
                context.Database.EnsureCreated();
                if (!context.Players.Any())
                {
                    context.Players.AddRange(new List<Player>
                    {
                        new()
                        {
                            Name = "John", Surname = "So", Sex = Sex.м, DateOfBirth = new DateTime(1975, 11, 11),
                            Team = new Team { Name = "MF Club" }, Country = Country.USA
                        },
                        new()
                        {
                            Name = "Lucas", Surname = "Romero", Sex = Sex.м, DateOfBirth = new DateTime(2018, 12, 29),
                            Team = new Team { Name = "Real Club" }, Country = Country.Italy
                        },
                        new()
                        {
                            Name = "Lucas", Surname = "Ogastus", Sex = Sex.м, DateOfBirth = new DateTime(2022, 08, 02),
                            Team = new Team { Name = "FF Club" }, Country = Country.USA
                        },
                        new()
                        {
                            Name = "John", Surname = "Otto", Sex = Sex.м, DateOfBirth = new DateTime(1985, 05, 12),
                            Team = new Team { Name = "Manchester" }, Country = Country.Italy
                        },
                        new()
                        {
                            Name = "Mickhail", Surname = "Petrov", Sex = Sex.м,
                            DateOfBirth = new DateTime(1974, 01, 22),
                            Team = new Team { Name = "СИП Клуб" }, Country = Country.Russia
                        },
                        new()
                        {
                            Name = "Oksana", Surname = "Enotova", Sex = Sex.ж, DateOfBirth = new DateTime(1984, 02, 02),
                            Team = new Team { Name = "СД Клуб" }, Country = Country.Russia
                        },
                        new()
                        {
                            Name = "Candice", Surname = "Siefwska", Sex = Sex.ж,
                            DateOfBirth = new DateTime(1978, 04, 29),
                            Team = new Team { Name = "FF Club" }, Country = Country.USA
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}