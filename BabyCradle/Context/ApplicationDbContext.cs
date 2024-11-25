using BabyCradle.Model;
using BabyCradle.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BabyCradle.Context
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Breathing> Breathing_readings { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Feeding> Feeding { get; set; }
        public DbSet<Heart> Heart_readings { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<spO2> spO2_readings { get; set; }
        public DbSet<Temprature> Temprature_readings { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }    
    }
}
