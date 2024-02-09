using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Optimization;
using Vidly_Video_Rental_App.Models;
using Vidly_Video_Rental_App.ViewModels;

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
            //Create the View Model
            var model =
                    _context.Customers
                    .Include(c => c.MembershipType)
                    .ToList();

            //Send the model to the view
            return View(model);
        }

        public ActionResult New()
        {
            //Build the view model:
            var model = new CustomerFormViewModel()
            {
                /*
                 *Important for validation:
                 * Properties of the customer object will be initialized to their default values, so the
                 * customer Id will be initialize to 0.
                 * This provides a value to the customer id when the hidden field is rendered
                 */
                Customer = new Customer(), 
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            //Send the View Model to the form
            return View("CustomerForm", model);
        }

        [ValidateAntiForgeryToken]
        [System.Web.Http.HttpPost]
        public ActionResult Save(Customer customer)
        {
            
            //If model state is not valid return to the customer form with the values sent
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                //Get the customer we wish to update from the Data base:
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                //Map the values of the customer send by the form to the customer in Database
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
                

            _context.SaveChanges();
            

            return RedirectToAction("Index", "Customer");
        }

        [System.Web.Http.HttpPost]
        public ActionResult Update(int id)
        {
            //Create the ViewModel
            var viewModel = new CustomerFormViewModel
            {
                Customer = _context.Customers.SingleOrDefault(c => c.Id == id),
                MembershipTypes = _context.MembershipTypes.ToList()
            };


            //Send the model to the form
            return View("CustomerForm", viewModel);
        }
    }
}