using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Video_Rental_App.Models
{
    public class Customer
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public DateTime? BirthDate { get; set; }

        //Navigation properties
        public MembershipType MembershipType { get; set; } //One-to-Many relationship with MembershipType
        public byte MembershipTypeId { get; set; } //Foreign Key


    }
}