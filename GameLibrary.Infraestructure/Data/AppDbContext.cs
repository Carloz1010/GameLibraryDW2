using GameLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Infraestructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.SKU);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(400);
                entity.Property(e => e.Genre).IsRequired().HasMaxLength(80);
                entity.Property(e => e.ReleaseDate).IsRequired();
                entity.Property(e => e.Developer).HasMaxLength(150);
            });

        }
    }
}
