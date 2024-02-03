using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly_Video_Rental_App.Dtos;
using Vidly_Video_Rental_App.Models;

namespace Vidly_Video_Rental_App.Controllers.Api
{
    /// <summary>
    /// We designed our API to be as stable and decoupled as possible. Instead of receiving or returning domain model
    /// objects, this API works with DTO objects.
    ///
    /// DTO reduce the chances of breaking the API as we refactor our domain models and prevents our API from working
    /// with implementation details that are prone to change frequently, which could affect existing clients that
    /// are dependent on the domain model objects
    /// 
    /// The actions in this API controller return an object of type IHttpActionResult, which is used for building
    /// HTTP responses from Web API controllers. The purpose of this interface is to provide a more flexible
    /// way to return HTTP responses from our Web API actions that also follow the RESTful conventions.
    /// </summary>
    /// 
    public class MoviesController : ApiController
    {
        //Access to the database
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Responds to GET /api/movies
        /// </summary>
        /// <returns>List of MovieDTO objects</returns>
        [HttpGet]
        public IEnumerable<MovieDTO> GetMovies()
        {
            return
                _context.Movies
                    .Include(m => m.Genre)//Eager load the Genre
                    .ToList() //Get a list of the movies in the Database
                    .Select(Mapper.Map<Movie, MovieDTO>); //Map each Movie to MovieDTO
        }


        [HttpDelete]
        public void DeleteMovie(int id)
        {
            //Get the movie the client wishes to delete
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            //Validate that the movie exist
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Remove the movie from the database
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }


    }
}
