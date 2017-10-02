using Autofac.Extensions.DependencyInjection;
using KonyvtarMVC.Web.Bootstrap;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace KonyvtarMVC.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .Build();
    }
}
