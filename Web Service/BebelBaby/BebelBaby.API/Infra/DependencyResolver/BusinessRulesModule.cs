﻿
using Autofac;
using BebelBaby.Core.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BebelBaby.API.Infra.DependencyResolver
{
    public class BusinessRulesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var assembly =  Assembly.Load("BebelBaby.Core.BusinessRules");

            builder
              .RegisterAssemblyTypes(assembly)
                .Where(p => p.Name.StartsWith("Regra"))
                .AsSelf();

            builder
                .RegisterType<ExecutorDeRegrasDeNegocio>()
                    .AsImplementedInterfaces(); 

            builder.Register<Func<Type, IRegraDeNegocio>>(context =>
                {
                    var componentContext = context.Resolve<IComponentContext>();

                    return type =>
                    {
                        var regraDeNegocio = componentContext.Resolve(type);

                        return (IRegraDeNegocio)regraDeNegocio;
                    };
                });
        }
    }
}