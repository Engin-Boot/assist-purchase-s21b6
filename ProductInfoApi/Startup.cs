using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductInfoApi.EmailProvider;
using ProductInfoApi.EmailProviderService;
using ProductInfoApi.Repository;

namespace ProductInfoApi
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {Configuration = configuration;}

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); 
            services.AddSingleton<ICharacteristicWiseFilter, CharacteristicWiseFilter>();
            services.AddSingleton<IEmailProvider, EmailNotifier>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseMvc();
        }
    }
}
