using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StationManager>().As<IStationService>().SingleInstance();
            builder.RegisterType<EfStationDal>().As<IStationDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<BranchManager>().As<IBranchService>().SingleInstance();
            builder.RegisterType<EfBranchDal>().As<IBranchDal>().SingleInstance();

            builder.RegisterType<BusOwnerManager>().As<IBusOwnerService>().SingleInstance();
            builder.RegisterType<EfBusOwnerDal>().As<IBusOwnerDal>().SingleInstance();

            builder.RegisterType<BusManager>().As<IBusService>().SingleInstance();
            builder.RegisterType<EfBusDal>().As<IBusDal>().SingleInstance();

            builder.RegisterType<BusStaffManager>().As<IBusStaffService>().SingleInstance();
            builder.RegisterType<EfBusStaffDal>().As<IBusStaffDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<JourneyManager>().As<IJourneyService>().SingleInstance();
            builder.RegisterType<EfJourneyDal>().As<IJourneyDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                   .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                   {
                       Selector = new AspectInterceptorSelector()
                   }).SingleInstance();
        }
    }
}
