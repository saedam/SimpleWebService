using Microsoft.EntityFrameworkCore;
using SimpleWebService.Models.DbModels;
using SimpleWebService.Models.Entities;

namespace SimpleWebService.DAL
{
    public class SimpleDBContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<FactoriesToCustomer> FactoriesToCustomer { get; set; }

        public DbSet<GroupCustomerRecord> GroupCustomerRecords { get; set; }

        public SimpleDBContext(DbContextOptions<SimpleDBContext> options) : base(options)
        {

        }
      
    }
}
