using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly_Video_Rental_App.Models
{
    /// <summary>
    /// DbContext of our application. It provides a gateway to the database
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //DbSets for the domain models of the application:
        // In order to create a table to store the domain data we must first create its DbSet
        public DbSet<Customer> Customers { get; set; }// Access to the Customers table
        public DbSet<Movie> Movies { get; set; } //Access to the Movies table
        public DbSet<MembershipType> MembershipTypes { get; set; } //Access to the MembershipType table
        public DbSet<Genre> Genres { get; set; } //Access to the Genres table
        public DbSet<Rental> Rentals { get; set; } //Access to the Rentals table

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}