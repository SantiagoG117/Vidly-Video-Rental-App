using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Video_Rental_App.Models;

namespace Vidly_Video_Rental_App.ViewModels
{
    public class MovieViewModel
    {
        
        public Movie Movie { get; set; }
        public IList<Genre> Genres { get; set; }

        /// <summary>
        /// Read only property.  
        /// </summary>
        public string Title
        {
            get
            {
                if (Movie != null) //&& Movie.Id != 0
                    return "Edit movie";
                return "New Movie";
            }
        }

        
    }
}