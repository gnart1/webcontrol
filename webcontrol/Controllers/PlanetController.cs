using Microsoft.AspNetCore.Mvc;
using webcontrol.Services;

namespace webcontrol.Controllers
{
  
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;

        private readonly ILogger<PlanetController> _logger;

        public  PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }
    
        public IActionResult Index()
        {
            return View();
        }
        //router action
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name { get; set; }
        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}
