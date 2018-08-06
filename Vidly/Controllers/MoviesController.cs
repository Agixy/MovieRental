using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public virtual ViewResult Index()
        {
            var moviesList = _context.Movies.Include(m => m.Genre).ToList();

            return View(moviesList);
        }

        [Route("/{id}")]
        public virtual ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


        public virtual ActionResult New()
        {
            var generes = _context.Generes.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Generes = generes
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public virtual ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movieInDb.DateAdded;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var ViewModel = new MovieFormViewModel
            {
                Movie = movie,
                Generes = _context.Generes.ToList()
            };

            return View("MovieForm", ViewModel);
        }
    }
}