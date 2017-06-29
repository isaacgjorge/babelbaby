using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Data.Entity;
using EasyCare.Repository;
using EasyCare.Repository.Common;

namespace EasyCare.API.Infra.DependencyResolver
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(DataContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitWork)).As(typeof(IUnitWork)).InstancePerRequest();

        }
    }
}