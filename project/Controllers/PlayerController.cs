using System.Diagnostics;
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
            return View();
        }

        public void Add()
        {
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}