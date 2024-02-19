using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_Video_Rental_App.Dtos
{
    public class RentalDTO
    {
        public int CustomerId { get; set; }
        public IList<int> MovieIds { get; set; }

    }
}