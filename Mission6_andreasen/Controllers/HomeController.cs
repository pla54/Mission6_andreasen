using Mission6_andreasen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mission6_andreasen.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext temp) 
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetToKnow()
        {
            return View("GetToKnow");
        }
        [HttpGet]
        public IActionResult MovieAdd()
        {
            return View("MovieAdd");
        }

        [HttpPost]
        public IActionResult MovieAdd(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation");
        }
    }
}
