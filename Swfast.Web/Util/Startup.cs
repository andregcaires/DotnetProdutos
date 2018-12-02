using Microsoft.Extensions.DependencyInjection;
using Swfast.Data;
using Swfast.Data.Repositories;
using Swfast.Web.Areas.Api.Controllers;
using Swfast.Web.Areas.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Swfast.Web.Util
{

    public class Startup
    {
        public static void Bootstrapper(HttpConfiguration config)
        {
            var provider = Configuration();
            var resolver = new DefaultDependencyResolver(provider);

            config.DependencyResolver = resolver;
        }

        private static IServiceProvider Configuration()
        {
            var services = new ServiceCollection();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(ICategoriaController),typeof(CategoriaController));
            services.AddTransient(typeof(ProdutoController));

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}