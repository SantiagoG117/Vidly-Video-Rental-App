using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Video_Rental_App.Dtos
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public byte MembershipTypeId { get; set; }
        public MembershipTypeDTO MembershipType { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public IList<MovieDTO> Movies { get; set; } //One-to-Many relationship
    }

    
}