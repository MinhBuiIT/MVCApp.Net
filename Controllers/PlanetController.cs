using Microsoft.AspNetCore.Mvc;
using MVCApp.Services;

namespace MVCApp.Controllers
{
    [Route("he-mat-troi/[action]")]//Khi đặt route ở controller thì các action phải đặt route ngoại trừ khi dùng [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        public PlanetController(PlanetService planetService) { 
            _planetService = planetService;
        }

        // /he-mat-troi/Index/Planet/Index/viewplanet
        //[Route("/viewplanet")]
        [Route("[controller] - [action].html",Order = 2)] //Order độ ưu tiên
        [Route("[controller]/[action]/viewplanet",Order = 1)]
        //Nếu viết Route("/...") thì nó sẽ ko sử dụng route của controller
        public IActionResult Index()
        {
            return View();
        }
        [BindProperty(SupportsGet=true,Name = "action")]
        public string NamePlanet { get;set; }
        public IActionResult Mercury()
        {
            var planet = _planetService.Where(p => p.Name == NamePlanet).FirstOrDefault();
            return View("Details",planet);
        }
        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.Name == NamePlanet).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == NamePlanet).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.Name == NamePlanet).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Jupiter()
        {
            var planet = _planetService.Where(p => p.Name == NamePlanet).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Saturn()
        {
            var planet = _planetService.Where(p => p.Name == NamePlanet).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Uranus()
        {
            var planet = _planetService.Where(p => p.Name == NamePlanet).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Neptune()
        {
            var planet = _planetService.Where(p => p.Name == NamePlanet).FirstOrDefault();
            return View("Details", planet);
        }

        [Route("/planetInfo/{id:int?}")] // không bị ảnh hưởng bởi route controller
        public IActionResult PlanetInfo(int? id)
        {
            if(id == null)
            {
                TempData["StatusMessage"] = "Not Found Planet";
                return LocalRedirect(Url.Action("Index", "Home"));
            }
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Details", planet);
        }
    }
}
