using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly_Video_Rental_App.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// <summary>
    /// Holds the profile data for the user's in our application. We can add new profile data
    /// by adding more properties to the ApplicationUser class.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

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
        public DbSet<Genre> Genres { get; set; }

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