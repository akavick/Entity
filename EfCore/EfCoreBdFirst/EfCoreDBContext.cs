using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCoreBdFirst
{
    public partial class EfCoreDBContext : DbContext
    {

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable 1030
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
#pragma warning restore 1030
                optionsBuilder.UseSqlServer(@"Server=SeaOfLove; Database=EfCoreDB; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Persons")
                      .Property(e => e.Sex).HasDefaultValueSql("((0))");
                entity.Property(e => e.Id).Metadata.IsPrimaryKey();
            });
        }
    }
}
