namespace O365.Services.Rest
{
    using O365.Services.Rest;
    using O365.Services.Rest.Repositories;
    using O365.Services.Rest.Repositories.Interfaces;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using System;
    using System.Web;
    using System.Web.Http;

    public class WebApiApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            base.OnApplicationStarted();
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            RegisterServices(kernel);
            // Install our Ninject-based IDependencyResolver into the Web API config
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            // This is where we tell Ninject how to resolve service requests
            kernel.Bind<ISampleRepository>().To<SampleRepository>();
            kernel.Bind<ISPRepository>().To<SPRepository>().InRequestScope();
        }
    }
}