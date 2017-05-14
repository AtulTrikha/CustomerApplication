using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerApplication.Models.Customer;

namespace CustomerApplication.ViewModels.Customer
{
    public class IndividualCustomerViewModel
    {
        public IndividualCustomer Customer { get; set; }

        public List<IndividualCustomer> Customers { get; set; }
    }
}