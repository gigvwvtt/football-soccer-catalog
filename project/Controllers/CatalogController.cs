using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Models;

namespace project.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        private List<PlayerViewModel> _players = new List<PlayerViewModel>()
        {
            new("John", "So", "male", 22222, "MFClub", "UK"),
            new("Lucas", "ROmero", "male", 645643, "CClub", "Canada")
        };
        
        public IActionResult ShowPlayers()
        {
            return View(_players);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}