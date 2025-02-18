using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Business.Implementations;
using Business.Interfaces;
using Core.Interfaces;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;

namespace CrossCutting.DependencyInjection.Autofac
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)); 
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<NorthwindContext>()
            .AsSelf()
            .InstancePerLifetimeScope();       
        }
    }
}