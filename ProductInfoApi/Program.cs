using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ProductInfoApi
{
    [ExcludeFromCodeCoverage]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        public static void Main(string[] args) 
        { CreateWebHostBuilder(args).Build().Run(); }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        { return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>(); }
    }
}
