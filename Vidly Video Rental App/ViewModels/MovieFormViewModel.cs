using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly_Video_Rental_App.Models;

namespace Vidly_Video_Rental_App.ViewModels
{

    /// <summary>
    ///
    /// Pure view model: To present empty initial values in the movies form, we added the values of the movie
    /// that we need to capture in the form and make them nullable. This will ensure that the form won't be pre-populated
    /// with the default values of each field. 
    ///
    ///
    /// 
    /// </summary>
    public class MovieFormViewModel
    {
        
        public IList<Genre> Genres { get; set; }

        /// <summary>
        /// Read only property.  
        /// </summary>
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit movie" : "New Movie";
            }
        }

        //Movie properties:
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }


        //Navigation Properties
        [Required]
        public byte? GenreId { get; set; } //ForeignKey: Used to identify which genre belongs to which movie


        //Constructors

        //For Update action
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        //For creating a new movie
        public MovieFormViewModel()
        {
            /*
             * By providing a value to the movie id we ensure that the hidden field for movie id passed in the form
             * gets populated
             * This provides a value to the movie id when the hidden field is rendered
             */
           
            Id = 0;
        }

    }
}