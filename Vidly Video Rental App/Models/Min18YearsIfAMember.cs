using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Video_Rental_App.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Access to the containing class: customer
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo )
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required");

            //Calculate age of the customer:
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year; //TODO Replace with a correct way of calculate age

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old to get a membership");
        }
    }
}