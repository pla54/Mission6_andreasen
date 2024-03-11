using Mission6_andreasen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_andreasen.Controllers
{
    //This is my home controller with all the different needed actions
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

        //Get and post method for adding a movie to the database and checking for a valid entry
        [HttpGet]
        public IActionResult MovieAdd()
        {

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieAdd", new Movie());
        }

        [HttpPost]
        public IActionResult MovieAdd(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }

            //_context.Movies.Add(response);
            //_context.SaveChanges();
            //return View("Confirmation");
        }

        //The list of movies view for editing and deleting
        public IActionResult MovieList()
        {
            var Movies = _context.Movies
                .OrderBy(x => x.Title)
                .ToList();

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(Movies);
        }

        //get and post methods for edit with valiadation 

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieAdd", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedInfo);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View("MovieAdd", updatedInfo);
            }
        }

        //Get and post methods for deleting with a confirmation page

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieID == id);

            return View("Delete", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
