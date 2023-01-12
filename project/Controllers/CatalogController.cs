using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Models.Interfaces;

namespace project.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IPlayersRepository _playersRepository;

        public CatalogController(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        private testData populate = new();
        

        public IActionResult Index()
        {
            //test
            //populate.PopulateData(_playersRepository);
            
            return View(GetPlayersFromDb());
        }
        
        [HttpPost]
        public ActionResult Update([FromBody] PlayerModelView player)
        {
            if (ModelState.IsValid)
            {
                _playersRepository.UpdatePlayer(player);

                return StatusCode((int)HttpStatusCode.OK, "Успешно обновлено");
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Неправильные данные!");
            }
        }

        private IEnumerable<PlayerModelView> GetPlayersFromDb()
        {
            return _playersRepository.GetAllPlayers().OrderBy(p=>p.PlayerId);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}