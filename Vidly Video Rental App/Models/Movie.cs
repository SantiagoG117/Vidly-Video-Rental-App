using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        //Navigation properties
        
        public Genre Genre { get; set; } //One-toMany relationship with Movie
        [Required]
        public byte GenreId { get; set; } //Foreign Key

    }
}