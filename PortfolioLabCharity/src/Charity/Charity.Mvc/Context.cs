using Charity.Mvc.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Charity.Mvc
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Institution> Institutions { get; set; }
    }
}