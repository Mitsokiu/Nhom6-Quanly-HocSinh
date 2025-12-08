using System.Data.Entity;

namespace DTO
{
    public class SchoolDbContext : DbContext
    {
        // constructor trỏ tới connection string trong App.config
        public SchoolDbContext() : base("name=school")
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<GradeLevel> GradeLevels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Class>()
                        .HasRequired(c => c.GradeLevel)
                        .WithMany(g => g.Classes)
                        .HasForeignKey(c => c.GradeId);
        }
    }
}
