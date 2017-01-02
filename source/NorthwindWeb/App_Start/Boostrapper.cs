using Autofac;
using Autofac.Integration.Mvc;
using NorthwindModel.Infrastructure;
using NorthwindModel.Interface;
using NorthwindModel.Repository;
using NorthwindService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindWeb
{
    public class Boostrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            //逐一設定寫法
            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>().InstancePerRequest();

            //該 Assembly 中每一個尾名 Repository 的 type 與其所實作的介面對應，生命週期為每一次 Request
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}