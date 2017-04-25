using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlayGround.Data.Entity;

namespace PlayGround.Data
{
    public partial class PlaygroundContext : DbContext
    {
        public virtual DbSet<Imports> Imports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlite(@"data source=""C:\Users\Home-PC\Documents\Visual Studio 2017\Projects\PlayGround\PlayGroundDB.db""");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Imports>(entity =>
            {
                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.PeriodEnd).HasColumnType("DATE");

                entity.Property(e => e.PeriodStart).HasColumnType("DATE");
            });
        }
    }
}