using System.Diagnostics;
using System.Linq;
using System.Text.Json;
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
        
        public IActionResult Index()
        {
            return View(moq.Players);
        }
        
        [HttpPost]
        public ActionResult Update([FromBody] PlayerModelView player)
        {
            var playerToEdit = moq.Players.FirstOrDefault(p => p.PlayerId == player.PlayerId);
            if (playerToEdit != null)
            {
                playerToEdit.Name = player.Name;
                playerToEdit.Name = player.Surname;
                playerToEdit.Sex = player.Sex;
                playerToEdit.DateOfBirth = player.DateOfBirth.Date;
                playerToEdit.Team = player.Team;
                playerToEdit.Country = player.Country;
            }

            return new EmptyResult();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}