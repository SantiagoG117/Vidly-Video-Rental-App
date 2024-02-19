using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Video_Rental_App.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [DisplayName("Birth Date")]
        [Min18YearsIfAMember]
        // If the user selects a Membership type different than 'Pay as you go' it must provide the Birthdate and it 
        // must be at least 18 years of age.
        public DateTime? BirthDate { get; set; }

        //Navigation properties
        public MembershipType MembershipType { get; set; } //One-to-One relationship with MembershipType

        [DisplayName("Membership Type")]
        public byte MembershipTypeId { get; set; } //Foreign Key

        
    }
}