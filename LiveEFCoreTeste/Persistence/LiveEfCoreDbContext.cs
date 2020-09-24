using LiveEFCoreTeste.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveEFCoreTeste.Persistence
{
    public class LiveEfCoreDbContext : DbContext
    {
        public LiveEfCoreDbContext(DbContextOptions<LiveEfCoreDbContext> options) : base(options)
        {

        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API
            modelBuilder
                .Entity<School>()
                .ToTable("School");

            modelBuilder
                .Entity<School>()
                .HasKey(s => s.Id);

            modelBuilder
                .Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder
                .Entity<ContactInformation>()
                .HasKey(s => s.Id);

            //modelBuilder
            //    .Entity<School>()
            //    .Property(s => s.Id)
            //    .HasDefaultValueSql("NEWID()");

            modelBuilder
                .Entity<School>()
                .HasData(new School(1, "Escola Daora"), new School(2, "Escola Supimpa"));

            modelBuilder
                .Entity<School>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .HasDefaultValue("TITULO PADRAO")
                .HasColumnName("Name");

            // 1:N
            modelBuilder
                .Entity<School>()
                .HasMany(school => school.Students)
                .WithOne(s => s.School)
                .HasForeignKey(s => s.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            // 1:1
            modelBuilder
                .Entity<School>()
                .HasOne(s => s.ContactInformation)
                .WithOne()
                .HasForeignKey<ContactInformation>(s => s.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
