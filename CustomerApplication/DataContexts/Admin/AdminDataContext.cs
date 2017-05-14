using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CustomerApplication.Models.Admin;

namespace CustomerApplication.DataContexts.Admin
{
    public class AdminDataContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
        }

        public DbSet<User> Users { get; set; }

    }
}