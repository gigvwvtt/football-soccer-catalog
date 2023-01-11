using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Models;

namespace project.Controllers
{
    public class AddNewPlayerController : Controller
    {
        private readonly ILogger<CatalogController> _logger;

        public AddNewPlayerController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Teams = GetTeams();
            return View();
        }

        [HttpPost]
        public string Add(int id, string name, string surname, string sex, DateTime date, string team, string country)
        {
            if (ModelState.IsValid)
            {
                
            }
            var newPlayer = new PlayerModelView
            {
                Name = name,
                Surname = surname,
                Sex = sex,
                DateOfBirth = date,
                Team = team, 
                Country = country
            };

            moq.Players.Add(newPlayer);
            //добавление в БД
            return "Успешно";
        }

        private IEnumerable<string> GetTeams()
        {
            return moq.Players.Select(p => p.Team).ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}