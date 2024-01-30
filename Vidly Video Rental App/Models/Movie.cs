using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Video_Rental_App.Models
{
    public class Movie
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte NumberInStock { get; set; }

        //Navigation properties
        [Required]
        public Genre Genre { get; set; } //One-toMany relationship with Movie
        public byte GenreId { get; set; } //Foreign Key

    }
}