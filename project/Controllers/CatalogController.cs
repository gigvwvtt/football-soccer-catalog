using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Data.Interfaces;
using project.Models;
using project.ViewModels;

namespace project.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var players = await _catalogRepository.GetAllPlayers();

            var orderedById = players.Select(editPlayerVM => new CreateOrEditPlayerViewModel
                {
                    Id = editPlayerVM.Id,
                    Country = editPlayerVM.Country,
                    DateOfBirth = editPlayerVM.DateOfBirth,
                    Name = editPlayerVM.Name,
                    Sex = editPlayerVM.Sex,
                    Surname = editPlayerVM.Surname,
                    Team = editPlayerVM.Team,
                    TeamId = editPlayerVM.TeamId
                })
                .ToList().OrderBy(p => p.Id);

            return View(orderedById);
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            //var currentId = HttpContext.User.
            var availableTeams = _catalogRepository.GetAllTeams().Result.Select(t => t.Name).ToList();
            var createOrEditPlayerViewModel = new CreateOrEditPlayerViewModel { AvailableTeams = availableTeams };

            if (id != 0)
            {
                var foundPlayer = await _catalogRepository.GetPlayerByIdAsync(id);
                if (foundPlayer == null) return View("Error");
                createOrEditPlayerViewModel.Id = foundPlayer.Id;
                createOrEditPlayerViewModel.Name = foundPlayer.Name;
                createOrEditPlayerViewModel.Surname = foundPlayer.Surname;
                createOrEditPlayerViewModel.Sex = foundPlayer.Sex;
                createOrEditPlayerViewModel.DateOfBirth = foundPlayer.DateOfBirth;
                createOrEditPlayerViewModel.TeamId = foundPlayer.TeamId;
                createOrEditPlayerViewModel.Team = foundPlayer.Team;
                createOrEditPlayerViewModel.Country = foundPlayer.Country;
            }

            return View(createOrEditPlayerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(CreateOrEditPlayerViewModel createOrEditPlayerVM)
        {
            if (ModelState.IsValid)
            {
                //editing existing player
                if (createOrEditPlayerVM.Id != 0)
                {
                    var foundPlayer = await _catalogRepository.GetPlayerByIdAsync(createOrEditPlayerVM.Id);
                    if (foundPlayer == null) return View("Error");
                    
                    foundPlayer.Name = createOrEditPlayerVM.Name;
                    foundPlayer.Surname = createOrEditPlayerVM.Surname;
                    foundPlayer.Sex = createOrEditPlayerVM.Sex;
                    foundPlayer.DateOfBirth = createOrEditPlayerVM.DateOfBirth;
                    foundPlayer.TeamId = _catalogRepository.GetAllTeams().Result.FirstOrDefault(t=>t.Name == createOrEditPlayerVM.Team?.Name)?.Id;
                    foundPlayer.Country = createOrEditPlayerVM.Country;
                    
                    _catalogRepository.Update(foundPlayer);
                    return RedirectToAction("Index");
                }
                //creating new player
                else
                {
                    var player = new Player
                    {
                        Name = createOrEditPlayerVM.Name,
                        Surname = createOrEditPlayerVM.Surname,
                        DateOfBirth = createOrEditPlayerVM.DateOfBirth,
                        Country = createOrEditPlayerVM.Country,
                        TeamId = _catalogRepository.GetAllTeams().Result.FirstOrDefault(x=>x.Name == createOrEditPlayerVM.Team?.Name)?.Id,
                        Sex = createOrEditPlayerVM.Sex
                    };
                    _catalogRepository.Add(player);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "CreateOrEdit player error");
                return View(createOrEditPlayerVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _catalogRepository.GetPlayerByIdAsync(id);
            if (player == null)
            {
                return View("Error");
            }

            _catalogRepository.Delete(player);
            return RedirectToAction("Index");
        }
    }
}