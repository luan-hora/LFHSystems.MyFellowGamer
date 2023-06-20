using LFHSystems.MyFellowGamer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LFHSystems.MyFellowGamer.Repository
{
    public class MyDbContext : DbContext
    {
        public DbSet<PublisherModel> Publisher { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PublisherModel>(e =>
            {
                e
                .ToTable("Tb_Publishers")
                .HasKey(k => k.ID);

                e
                .Property(p => p.ID)
                .ValueGeneratedOnAdd();
            });
        }
    }
}
