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

        //Insert
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

        //Get
         public List<IndividualCustomer> GET()
        {
            // Read the query string
            var allUrlKeyValues = ControllerContext.Request.GetQueryNameValuePairs();

            string CustomerCode = allUrlKeyValues.
                            SingleOrDefault(x => x.Key == "CustomerCode").Value;

            string CustomerName = allUrlKeyValues.
                            SingleOrDefault(x => x.Key == "CustomerName").Value;

            CustomerDataContext customerDataAccess = new CustomerDataContext();
            List<IndividualCustomer> customers = null;
            if (CustomerName != null)
            {
                customers = (from item in customerDataAccess.Customers
                             where item.CustomerName.ToUpper() == CustomerName.ToUpper()
                             select item).ToList<IndividualCustomer>();
            }
            else if (CustomerCode != null)
            {
                customers = (from item in customerDataAccess.Customers
                             where item.CustomerCode.ToUpper() == CustomerCode.ToUpper()
                             select item).ToList<IndividualCustomer>();
            }
            else
            {
                customers = customerDataAccess.Customers.ToList<IndividualCustomer>();
            }

            return customers;
        }

         public IndividualCustomer GET(String CustomerCode)
         {
             var allUrlKeyValues = ControllerContext.Request.GetQueryNameValuePairs();
             string CustomerCode1 = allUrlKeyValues.
                            SingleOrDefault(x => x.Key == "CustomerCode").Value;

             string CustomerName1 = allUrlKeyValues.
                             SingleOrDefault(x => x.Key == "CustomerName").Value;

             CustomerDataContext customerDataAccess = new CustomerDataContext();
             IndividualCustomer customers = null;
             customers = (from item in customerDataAccess.Customers
                          where item.CustomerCode.ToUpper() == CustomerCode.ToUpper()
                          select item).FirstOrDefault();
            
             return customers;
         }

        //Update
        public List<IndividualCustomer> PUT(IndividualCustomer customer)
        {
            CustomerDataContext customerDataAccess = new CustomerDataContext();
            //Update Customer
            IndividualCustomer customerUpdate = (from item in customerDataAccess.Customers
                                                 where item.CustomerCode == customer.CustomerCode
                                                 select item).FirstOrDefault();
            customerUpdate.CustomerName = customer.CustomerName;
            customerUpdate.CustomerDob = customer.CustomerDob;
            customerUpdate.CustomerAmount = customer.CustomerAmount;

            //Return Customer
            List<IndividualCustomer> customers = customerDataAccess.Customers.ToList<IndividualCustomer>();
            return customers;
        }

        //Update
        public List<IndividualCustomer> Delete(IndividualCustomer customer)
        {
            CustomerDataContext customerDataAccess = new CustomerDataContext();
            //Delete Customer
            IndividualCustomer customerDelete = (from item in customerDataAccess.Customers
                                                 where item.CustomerCode == customer.CustomerCode
                                                 select item).FirstOrDefault();
            customerDataAccess.Customers.Remove(customerDelete);
            customerDataAccess.SaveChanges();
            //Return Customer
            List<IndividualCustomer> customers = customerDataAccess.Customers.ToList<IndividualCustomer>();
            return customers;
        }
    }
}
