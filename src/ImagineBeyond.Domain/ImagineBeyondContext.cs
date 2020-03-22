using System;
using System.Collections.Generic;
using System.Text;
using ImagineBeyond.Customer.Entity;
using Microsoft.EntityFrameworkCore;

namespace ImagineBeyond.Domain
{
   public class ImagineBeyondContext : DbContext
    {

        private string _connectionString;

        public ImagineBeyondContext(DbContextOptions<ImagineBeyondContext> options) : base(options)
        {
        }

        public ImagineBeyondContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!string.IsNullOrEmpty(_connectionString))
        //        optionsBuilder.UseMySql(_connectionString);
        //}

        public virtual DbSet<CustomerEntity> Customer { get; set; }
    }
}
