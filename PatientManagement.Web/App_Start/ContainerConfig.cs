using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PatientManagement.Data.Services;

namespace PatientManagement.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            // register mvc controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            // register appDbContext
            builder.RegisterType<AppDbContext>().InstancePerRequest();


            builder.RegisterType<PatientRepository>()
                   .As<IPatientRepository>()
                   .InstancePerRequest();

            var container = builder.Build();

            // resolve dependency for mvc
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}