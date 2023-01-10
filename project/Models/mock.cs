using System.Collections.Generic;

namespace project.Models
{
    public static class mock
    {
        public static List<PlayerViewModel> Players = new List<PlayerViewModel>()
        {
            new("John", "So", "male", 22222, "MFClub", "UK"),
            new("Lucas", "ROmero", "male", 645643, "CClub", "Canada")
        };
    }
}