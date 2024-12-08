namespace BabyCradle.Context
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تعريف ValueConverter
            var timeSpanConverter = new TimeSpanToLongConverter();

            // تطبيق ValueConverter على الخاصية IntervalAfterBirth
            modelBuilder.Entity<VaccinationTemplate>()
                .Property(v => v.IntervalAfterBirth)
                .HasConversion(timeSpanConverter);

            // تهيئة بيانات اللقاحات (Seed Data)
            modelBuilder.Entity<VaccinationTemplate>().HasData(
                new VaccinationTemplate { Id = 1, VaccineName = "Hepatitis B Vaccine (HBV)", Information = "Protects against Hepatitis B. First dose is given within 24 hours of birth.", IntervalAfterBirth = TimeSpan.FromDays(1) },
                new VaccinationTemplate { Id = 2, VaccineName = "DTaP (Diphtheria, Tetanus, Pertussis)", Information = "Protects against Diphtheria, Tetanus, and Pertussis.", IntervalAfterBirth = TimeSpan.FromDays(60) },
                new VaccinationTemplate { Id = 3, VaccineName = "IPV (Inactivated Polio Vaccine)", Information = "Protects against Polio.", IntervalAfterBirth = TimeSpan.FromDays(60) },
                new VaccinationTemplate { Id = 4, VaccineName = "Hib (Haemophilus Influenzae Type B)", Information = "Protects against Haemophilus influenzae infections.", IntervalAfterBirth = TimeSpan.FromDays(60) },
                new VaccinationTemplate { Id = 5, VaccineName = "PCV (Pneumococcal Conjugate Vaccine)", Information = "Protects against pneumococcal infections.", IntervalAfterBirth = TimeSpan.FromDays(60) },
                new VaccinationTemplate { Id = 6, VaccineName = "Rotavirus Vaccine", Information = "Protects against Rotavirus.", IntervalAfterBirth = TimeSpan.FromDays(60) },
                new VaccinationTemplate { Id = 7, VaccineName = "Measles Vaccine", Information = "Protects against Measles. First dose is given at 9 months.", IntervalAfterBirth = TimeSpan.FromDays(270) },
                new VaccinationTemplate { Id = 8, VaccineName = "MMR (Measles, Mumps, Rubella)", Information = "Protects against Measles, Mumps, and Rubella.", IntervalAfterBirth = TimeSpan.FromDays(365) },
                new VaccinationTemplate { Id = 9, VaccineName = "Hepatitis A Vaccine", Information = "Protects against Hepatitis A.", IntervalAfterBirth = TimeSpan.FromDays(365) }
            );
        }


        public DbSet<Breathing> Breathing_readings { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Feeding> Feeding { get; set; }
        public DbSet<Heart> Heart_readings { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<spO2> spO2_readings { get; set; }
        public DbSet<Temprature> Temprature_readings { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<VaccinationTemplate> VaccinationTemplates { get; set; }       

    }
}
