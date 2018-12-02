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

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Categoria> Categoria  { get; set; }
    }
}
