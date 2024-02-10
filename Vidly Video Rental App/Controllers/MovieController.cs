using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using Vidly_Video_Rental_App.Models;
using Vidly_Video_Rental_App.ViewModels;

namespace Vidly_Video_Rental_App.Controllers
{
    public class MovieController : Controller
    {
        //Access the Database
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movie
        public ActionResult Index()
        {
            //Create the model
            var model =
                _context.Movies //Get the movies from the database
                    .Include(m => m.Genre) //Eager load the genres
                    .ToList();

            //According to the current user, send the model to a specific view
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List", model);
            
            return View("ReadOnlyList", model);
            
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            //Get the Genres:
            var genres = _context.Genres.ToList();
            
            //Create the model:
            var viewModel = new MovieFormViewModel
            {
                //Necessary for populating the dropdown list
                Genres = genres
            };


            //Send the model to the view

            return View("MovieForm", viewModel);
        }


        /// <summary>
        /// Model Binding: MVC framework binds (maps) the data send by the form to the movie object set as argument
        /// because it identifies that the keys send in the form are prefixed with the word 'Movie'
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            //Validation
            if (!ModelState.IsValid)
            {
                //Recreate model sent by the form
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                //Send model back to the form
                return View("MovieForm", viewModel);
            }

            //If the movie does not exist, save it
            if (movie.Id == 0)
            {
                //Set the Genre of the movie
                movie.Genre = _context.Genres.SingleOrDefault(g => g.Id == movie.GenreId);
                _context.Movies.Add(movie);
            }
            else
            {
                //Get a movie from the Database with an id equal to the one send by the form
                var dbMovie = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                if (dbMovie != null)
                {
                    //Map the values of the movie send by the form to the movie in the Database
                    dbMovie.Name = movie.Name;
                    dbMovie.ReleaseDate = movie.ReleaseDate;
                    dbMovie.NumberInStock = movie.NumberInStock;
                    dbMovie.GenreId = movie.GenreId;
                }
            }


            //Save the changes
            _context.SaveChanges();

            //Redirect the view to the Index
            return RedirectToAction("Index", "Movie");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Update(int id)
        {
            //Get the movie from the database
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            

            //Build the ViewModel
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList(),
                
            };

            //Send the ViewModel to the form
            return View("MovieForm", viewModel);
        }
    }
}