﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Customer> Customers { get; set; } //what we actually call to access the table 

        public DbSet<Product> Products { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}