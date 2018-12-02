using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Swfast.Data;
using Swfast.Data.Repositories;
using Swfast.Web.Areas.Api.Controllers;
using Swfast.Web.Areas.Api.Interfaces;
using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Swfast.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //container.RegisterType<>(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<ICategoriaController, CategoriaController>();
            container.RegisterType<IProdutoController, ProdutoController>();
            container.RegisterType<IProdutoRepository, ProdutoRepository>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            var contextOptions = new DbContextOptionsBuilder()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["SwfastConnection"].ConnectionString)
                .Options;

            container.RegisterType<SwfastContext>(new InjectionConstructor(contextOptions));


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}