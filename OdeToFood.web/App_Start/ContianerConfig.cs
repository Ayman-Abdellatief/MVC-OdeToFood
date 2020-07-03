using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.web
{
    public class ContianerConfig
    {
        internal static void RegisterContianer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData>()
                .InstancePerRequest();

            builder.RegisterType<OdeToFoodDBContext>().InstancePerRequest();       
            var contianer = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(contianer));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(contianer);
        }
    }
}