using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Microsoft.Extensions.Configuration;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssignmentManager>().As<IAssignmentService>().SingleInstance();
            builder.RegisterType<EfAssignmentDal>().As<IAssignmentDal>().SingleInstance();

            builder.RegisterType<AssignmentListManager>().As<IAssignmentListService>().SingleInstance();
            builder.RegisterType<EfAssignmentListDal>().As<IAssignmentListDal>().SingleInstance();
            // builder.RegisterType<FileLogger>().As<ILogger>().SingleInstance();
            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();
                var key = configuration["Jwt:Key"];
                var issuer = configuration["Jwt:Issuer"];
                return new JwtTokenHelper(key, issuer);
            }).AsSelf().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
