using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Models;

namespace project.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ILogger<CatalogController> _logger;

        public PlayerController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowAddForm()
        {
            return View(GetTeams());
        }

        [HttpPost]
        public string Add(string name, string surname, string sex, int date, string team, string country)
        {
            var newPlayer = new PlayerViewModel(name, surname, sex, 1010, team, country);
             mock.Players.Add(newPlayer);
            //добавление в БД
            return "Успешно";
        }

        private IEnumerable<string> GetTeams()
        {
            return mock.Players.Select(p => p.Team).ToList();
        }

        public void Edit()
        {
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}