using System;
using System.Collections.Generic;

namespace project.Models
{
    public static class moq
    {
        public static List<PlayerModelView> Players = new List<PlayerModelView>()
        {
            new()
            {
                PlayerId = 1, Name = "John", Surname = "So", Sex = "мужской", DateOfBirth = DateTime.Today.Date,
                Team = "MFClub", Country = "США"
            },
            new()
            {
                PlayerId = 2, Name = "Lucas", Surname = "ROmero", Sex = "женский", DateOfBirth = DateTime.Today.Date,
                Team = "CClub", Country = "Италия"
            }
        };
    }
}