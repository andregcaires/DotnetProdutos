using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Swfast.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swfast.Data
{
    public class SwfastContext : DbContext
    {
        public SwfastContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>().HasMany(p => p.Produtos).WithOne(e => e.Categoria);
            modelBuilder.Entity<Produto>().HasOne(e => e.Categoria).WithMany(x => x.Produtos);
        }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Categoria> Categoria  { get; set; }
    }
}
