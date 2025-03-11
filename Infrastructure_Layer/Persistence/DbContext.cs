using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Week5.Domain_Layer.Entity;

namespace Week5.Infrastructure_Layer.Persistence
{
    public class Week5DbContext(DbContextOptions<Week5DbContext> options, IConfiguration configuration)
        : DbContext(options)
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<BehaviorScore> BehaviorScore { get; set; }
        public DbSet<Major> Major { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("❌ Connection String is not set in configuration.");
                }
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentClass>()
                .HasKey(sc => new { sc.StudentID, sc.ClassID });

            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentClass)
                .HasForeignKey(sc => sc.StudentID);

            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.Class)
                .WithMany(c => c.StudentClass)
                .HasForeignKey(sc => sc.ClassID);

            modelBuilder.Entity<BehaviorScore>()
                .HasKey(b => b.ScoreID);

            modelBuilder.Entity<BehaviorScore>()
                .HasOne(b => b.Student)
                .WithMany(s => s.BehaviorScore)
                .HasForeignKey(b => b.StudentID);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Major)
                .WithMany(m => m.Students)
                .HasForeignKey(s => s.MajorID);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Professor)
                .WithMany(p => p.Student)
                .HasForeignKey(s => s.ProfessorID);

            modelBuilder.Entity<Student>()
            .HasMany(s => s.BehaviorScore)
            .WithOne(bs => bs.Student)
            .HasForeignKey(bs => bs.StudentID)
            .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
