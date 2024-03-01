using CustomerDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerDataAccessLayer
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        public DbSet<CustomerDetail> NewCustomer { get; set; }
    }
}

