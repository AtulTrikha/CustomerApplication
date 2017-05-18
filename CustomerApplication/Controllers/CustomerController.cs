using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerApplication.Models.Customer;
using CustomerApplication.DataContexts.Customer;

namespace CustomerApplication.Controllers
{
    public class CustomerController : ApiController
    {

        public List<IndividualCustomer> POST(IndividualCustomer customer)
        {
            CustomerDataContext customerDataAccess = new CustomerDataContext();
            if (ModelState.IsValid)
                {
                    //Save Customer                    
                    customerDataAccess.Customers.Add(customer);
                    customerDataAccess.SaveChanges();
                }
        List<IndividualCustomer> customers = customerDataAccess.Customers.ToList<IndividualCustomer>();
        return customers;
        }

        public List<IndividualCustomer> GET()
        {
            CustomerDataContext customerDataAccess = new CustomerDataContext();
            List<IndividualCustomer> customers = customerDataAccess.Customers.ToList<IndividualCustomer>();
            return customers;
        }

        public List<IndividualCustomer> GET(string CustomerName)
        {
            CustomerDataContext customerDataAccess = new CustomerDataContext();
            List<IndividualCustomer> customers = (from item in customerDataAccess.Customers
                                                  where item.CustomerName.ToUpper() == CustomerName.ToUpper()
                                                  select item).ToList<IndividualCustomer>();
            return customers;
        }
    }
}
