using Autofac;
using Autofac.Integration.WebApi;
using BebelBaby.API.Infra.DependencyResolver;
using BebelBaby.API.Infra.DependencyResolver.Modules;
using System.Web.Http;

namespace BebelBaby.Api
{
    public class DependencyResolverConfig
    {
        public static void SetDependencyResolver()
        {
            var builder = new ContainerBuilder();
            var assembly = typeof(DependencyResolverConfig).Assembly;



            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(assembly);

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);            
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<EFModule>();
            builder.RegisterModule<UtilModule>();
            

            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));



            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
