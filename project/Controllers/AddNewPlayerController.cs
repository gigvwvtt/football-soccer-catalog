using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Models.Interfaces;

namespace project.Controllers
{
    public class AddNewPlayerController : Controller
    {
        private readonly IPlayersRepository _playersRepository;

        public AddNewPlayerController(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Teams = GetTeams();
            return View();
        }

        [HttpPost]
        public IActionResult Index(PlayerModelView player)
        {
            if (ModelState.IsValid)
            {
                _playersRepository.AddPlayer(player);
                
                ViewBag.Result = "Успешно добавлено!";
            }
            else
            {
                ViewBag.Result = "Данные не прошли валидацию!";
            }
            ViewBag.Teams = GetTeams();
            return View();
        }

        private List<string> GetTeams()
        {
            return _playersRepository.GetAllPlayers().Select(p => p.Team).Distinct().ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}