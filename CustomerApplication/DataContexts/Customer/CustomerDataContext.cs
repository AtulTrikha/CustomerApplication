using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CustomerApplication.Models.Customer;
using CustomerApplication.DataContexts.Customer;

namespace CustomerApplication.DataContexts.Customer
{
    public class CustomerDataContext : DbContext
    {


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CustomerMap());

        }

        public DbSet<IndividualCustomer> Customers { get; set; } 
    }
}