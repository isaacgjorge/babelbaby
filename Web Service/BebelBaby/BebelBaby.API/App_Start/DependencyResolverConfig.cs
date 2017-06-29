using Autofac;
using Autofac.Integration.WebApi;
using EasyCare.API.Infra.DependencyResolver;
using EasyCare.API.Infra.DependencyResolver.Modules;
using System.Web.Http;

namespace EasyCare.Api
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

            //builder.RegisterModule<QueueModule>();
            //builder.RegisterModule<FiltersModule>();
            //builder.RegisterModule<NHibernateModule>();
            //builder.RegisterModule<RepositoriesModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<EFModule>();
            builder.RegisterModule<UtilModule>();
            builder.RegisterModule<BusinessRulesModule>();
            //builder.RegisterModule<RulesModule>();

            //var container = builder.Build();

            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));



            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
