using Microsoft.EntityFrameworkCore;
using Ticket_System.Models;

namespace Ticket_System.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
