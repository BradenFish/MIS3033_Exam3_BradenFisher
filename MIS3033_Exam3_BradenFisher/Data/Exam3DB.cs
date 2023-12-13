using Microsoft.EntityFrameworkCore;
using MIS3033_Exam3_BradenFisher.Models;

namespace MIS3033_Exam3_BradenFisher.Data
{
    public class Exam3DB : DbContext
    {
        public DbSet<Order> Orders { get; set; }// Define a table in the database. 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=129.15.67.240;Database=fish0090exam3;Port=5432;Username=fish0090;Password=jFo9OvfVJ5QFHHspd1Au");
        }
    }

}
