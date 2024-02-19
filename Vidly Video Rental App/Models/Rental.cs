using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Video_Rental_App.Models
{
    /// <summary>
    /// Serves as Association table between Customer and Movies
    /// A customer can rent one or more movie and a movie can be rented by one or more customer.
    /// </summary>
    public class Rental
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        //Navigation properties
        [Required]
        public Customer Customer { get; set; } //One-to-One relationship with Customer
        [Required]
        public Movie Movie { get; set; } //One-to-One relationship with Movie


    }
}