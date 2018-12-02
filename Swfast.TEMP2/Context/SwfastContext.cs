using Swfast.TEMP2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Swfast.TEMP.Context
{
    public class SwfastContext : DbContext
    {

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
    }
}
