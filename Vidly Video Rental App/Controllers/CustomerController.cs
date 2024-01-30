using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Video_Rental_App.Models;

namespace Vidly_Video_Rental_App.Controllers
{
    public class CustomerController : Controller
    {
        //Generate the DbContext
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            //Create the model


            //Send the model to the vire
            return View();
        }
    }
}