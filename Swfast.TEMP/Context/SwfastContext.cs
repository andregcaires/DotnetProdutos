using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Swfast.TEMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swfast.TEMP.Context
{
    public class SwfastContext : DbContext
    {
        public SwfastContext(DbContextOptions<SwfastContext> options) : base(options)
        {
            
        }


        public DbSet<Produto> Produto { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
    }
}
