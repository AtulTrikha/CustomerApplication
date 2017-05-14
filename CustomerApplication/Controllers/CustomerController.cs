using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using CustomerApplication.Models.Customer;
using CustomerApplication.DataContexts.Customer;
using CustomerApplication.ViewModels.Customer;


namespace CustomerApplication.Controllers.Customer
{
    //[Authorize(Users = @"DESKTOP-IMS4T64\Atul")] --Not required for Form Authentication
    [Authorize]
    public class CustomerController : Controller
    {

        public ActionResult ShowCustomerView()
        {
            //Initialize ViewModel
            IndividualCustomerViewModel customerViewModel = new IndividualCustomerViewModel();
            customerViewModel.Customer = new IndividualCustomer();

            //Get Customer
            //customerViewModel.Customers = GetCustomer();

            //Show Customer View
            return View("IndividualCustomerView", customerViewModel);
        }

        public ActionResult ShowSearchCustomerView()
        {
            IndividualCustomerViewModel customerViewModel = new IndividualCustomerViewModel();
            customerViewModel.Customers = new List<IndividualCustomer>();
            return View("SearchCustomerView", customerViewModel);
        }

        public ActionResult SearchCustomer()
        {
            //TODO: Change in Future to Model Binder
            IndividualCustomerViewModel customerViewModel = new IndividualCustomerViewModel();
            String customerName = Request.Form["CustomerName"].ToString();

            //Get Customer
            customerViewModel.Customers = GetCustomer(customerName);

            //Show Customer View
            return View("SearchCustomerView", customerViewModel);
        }

        public ActionResult SaveCustomer()
        {
            try
            {
                IndividualCustomer customer = new IndividualCustomer();
                customer.CustomerCode = Request.Form["Customer.CustomerCode"];
                customer.CustomerName = Request.Form["Customer.CustomerName"];
                customer.CustomerDob = Convert.ToDateTime(Request.Form["Customer.CustomerDob"]);

                if (ModelState.IsValid)
                {
                    //Save Customer
                    CustomerDataContext customerDataAccess = new CustomerDataContext();
                    customerDataAccess.Customers.Add(customer);
                    customerDataAccess.SaveChanges();
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                    }
                }
            }

            //Send Customers
            return GetCustomerJson();
        }

        private List<IndividualCustomer> GetCustomer()
        {
            CustomerDataContext customerDataAccess = new CustomerDataContext();
            List<IndividualCustomer> customers = customerDataAccess.Customers.ToList<IndividualCustomer>();
            return customers;
        }

        private List<IndividualCustomer> GetCustomer(string customerName)
        {
            CustomerDataContext customerDataAccess = new CustomerDataContext();
            List<IndividualCustomer> customers = (from customer in customerDataAccess.Customers
                                                  where customer.CustomerName == customerName
                                                  orderby customer.CustomerName
                                                  select customer).ToList<IndividualCustomer>();
            return customers;
        }

        public JsonResult GetCustomerJson()
        {
            CustomerDataContext customerDataAccess = new CustomerDataContext();
            List<IndividualCustomer> customers = customerDataAccess.Customers.ToList<IndividualCustomer>();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }

    }
}