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
        
        public IActionResult ShowPlayers()
        {
            return View(mock.Players);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}