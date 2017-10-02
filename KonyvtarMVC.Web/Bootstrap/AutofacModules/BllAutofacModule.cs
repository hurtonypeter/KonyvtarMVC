using Autofac;
using Autofac.Extras.AggregateService;
using KonyvtarMVC.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonyvtarMVC.Web.Bootstrap.AutofacModules
{
    public class BllAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAggregateService<IBaseServiceAggregate>();

            builder.RegisterAssemblyTypes(typeof(IBaseServiceAggregate).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
