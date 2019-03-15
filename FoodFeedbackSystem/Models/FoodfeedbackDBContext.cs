using System;
using FoodFeedbackSystem.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodFeedbackSystem.Models
{
    public partial class FoodfeedbackDBContext : DbContext
    {
        public FoodfeedbackDBContext()
        {
        }

        public FoodfeedbackDBContext(DbContextOptions<FoodfeedbackDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=FoodfeedbackDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => new { e.SelectDate, e.TypeOfMeal, e.Email });

                entity.Property(e => e.SelectDate)
                    .HasColumnName("Select_Date")
                    .HasColumnType("date");

                entity.Property(e => e.TypeOfMeal)
                    .HasColumnName("Type_of_meal")
                    .HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
