using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Video_Rental_App.Models;

namespace Vidly_Video_Rental_App.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IList<MembershipType> MembershipTypes { get; set; }

        public string Title
        {
            get
            {
                if (Customer != null)
                    return "Edit Customer";

                return "New Customer";
            }
        }
    }
}