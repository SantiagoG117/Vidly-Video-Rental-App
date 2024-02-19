using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly_Video_Rental_App.Dtos;
using Vidly_Video_Rental_App.Models;
using Vidly_Video_Rental_App.ViewModels;

namespace Vidly_Video_Rental_App.Controllers.Api
{
    /// <summary>
    /// This API was designed to be as stable and decouple as possible. Instead of working with domain model objects, we
    /// set it to work with DTO objects
    /// </summary>
    public class RentalsController : ApiController
    {
        //Create access to the Database
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Creates a new Rental object using the IDs provided by the RentalDTO
        /// </summary>
        /// <param name="rentalDto"></param>
        /// <returns>
        /// Since we are not creating a single new object but multiple resources, we use the Ok() method instead of
        /// the Create() method
        ///
        /// </returns>
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateNewRental(RentalDTO rentalDto)
        { 

            //Load the customer:
            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);


            /*
             * Load the movies:
             * This code is the C# equivalent of: SELECT* FROM Movies WHERE Id IN (1,2,...)
             */
            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

         
            
            //Load the movies
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("The movie " + movie.Name + "is not available");

                movie.NumberAvailable--;

                //Create a new rental object for each movie using the selected customer
                var newRental = new Rental
                {
                    DateRented = DateTime.Now,
                    Customer = customer,
                    Movie = movie
                };
                //Add the new rental to the database
                _context.Rentals.Add(newRental);
            }
            _context.SaveChanges();

            return Ok();

        }

    }
}
