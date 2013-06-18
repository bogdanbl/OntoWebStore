using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OntoWebStore.Services;

namespace OntoWebStore.Infrastructure
{
    public class ControllersInstaller  : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient());

            container.Register(Component
                                .For<IControllerFactory>()
                                .UsingFactoryMethod(_ => new WindsorControllerFactory(container))
                                .LifeStyle.Singleton);

            container.Register(Component.For<IRdfTranslator>()
                                .UsingFactoryMethod(_ => new RdfTranslator(container.Resolve<IMongoDataContextProvider>()))
                                .LifeStyle.PerWebRequest);

            container.Register(Component.For<IMongoDataContextProvider>()
                                .UsingFactoryMethod(_ => new MongoDataContextProvider())
                                .LifeStyle.PerWebRequest);

            //container.Register(Component.For<IFormsAuthenticationService>()
            //                    .UsingFactoryMethod(_ => new FormsAuthenticationService())
            //                    .LifeStyle.PerWebRequest);

            //container.Register(Component.For<IMembershipService>()
            //                    .UsingFactoryMethod(_ => new AccountMembershipService())
            //                    .LifeStyle.PerWebRequest);
        }
    }
}