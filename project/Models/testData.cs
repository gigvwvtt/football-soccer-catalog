using System;
using System.Collections.Generic;
using project.Models.Interfaces;

namespace project.Models
{
    public class testData
    {
        //example data
        public void PopulateData(IPlayersRepository playersRepository)
        {
            var players = new List<PlayerModelView>()
            {
                new()
                {
                    Name = "John", Surname = "So", Sex = "м", DateOfBirth = new DateTime(1975,11,11),
                    Team = "MF Club", Country = "США"
                },
                new()
                {
                    Name = "Lucas", Surname = "Romero", Sex = "м", DateOfBirth = new DateTime(2018,12,29),
                    Team = "Real Club", Country = "Италия"
                },
                new()
                {
                    Name = "Lucas", Surname = "Ogastus", Sex = "м", DateOfBirth = new DateTime(2022,08,02),
                    Team = "FF Club", Country = "США"
                },
                new()
                {
                    Name = "John", Surname = "Otto", Sex = "м", DateOfBirth = new DateTime(1985,05,12),
                    Team = "Manchester", Country = "Италия"
                },
                new()
                {
                    Name = "Mickhail", Surname = "Petrov", Sex = "м", DateOfBirth = new DateTime(1974,01,22),
                    Team = "СИП Клуб", Country = "Россия"
                },
                new()
                {
                    Name = "Oksana", Surname = "Enotova", Sex = "ж", DateOfBirth = new DateTime(1984,02,02),
                    Team = "СД Клуб", Country = "Россия"
                },
                new()
                {
                    Name = "Candice", Surname = "Siefwska", Sex = "ж", DateOfBirth = new DateTime(1978,04,29),
                    Team = "FF Club", Country = "США"
                }
            };

            foreach (var player in players)
            {
                playersRepository.AddPlayer(player);
            }
        }
    }
}