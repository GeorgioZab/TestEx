using TestEx.Models;
using Microsoft.EntityFrameworkCore;

namespace TestEx.Data
{
    public class NutritionDbContext : DbContext
    {
        public NutritionDbContext(DbContextOptions<NutritionDbContext> options) : base(options) { }

        public DbSet<NutritionAssessment> Assessments { get; set; }
        public DbSet<AssessmentAnswer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NutritionAssessment>()
                .HasMany(a => a.Answers)
                .WithOne(b => b.NutritionAssessment)
                .HasForeignKey(b => b.NutritionAssessmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}