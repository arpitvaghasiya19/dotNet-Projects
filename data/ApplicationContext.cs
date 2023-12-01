using CodeFirstAjax.Models;
using Microsoft.EntityFrameworkCore;


namespace CodeFirstAjax.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
