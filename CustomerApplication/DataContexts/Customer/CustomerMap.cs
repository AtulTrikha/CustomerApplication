using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CustomerApplication.Models.Customer;

namespace CustomerApplication.DataContexts.Customer
{
    public class CustomerMap : EntityTypeConfiguration<IndividualCustomer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerId);

            // Properties
            this.Property(t => t.CustomerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CustomerName)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.CustomerDob)
                .IsRequired();

            this.Property(t => t.CustomerAmount)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.CustomerId).HasColumnName("Id");
            this.Property(t => t.CustomerName).HasColumnName("Name");
            this.Property(t => t.CustomerDob).HasColumnName("DateOfBirth");
            this.Property(t => t.CustomerCode).HasColumnName("Code");
            this.Property(t => t.CustomerAmount).HasColumnName("Amount");

        }
    }
}