using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Swfast.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Swfast.Web.Util
{
    // classe usada para habilitar migration
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SwfastContext>
    {
        public SwfastContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SwfastContext>();
            var connectionString = ConfigurationManager.ConnectionStrings["SwfastConnection"].ConnectionString;
            builder.UseSqlServer(connectionString);
            return new SwfastContext(builder.Options);

        }
    }
}