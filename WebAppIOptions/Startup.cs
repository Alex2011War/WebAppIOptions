using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppIOptions
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("person.json");
            AppConfiguration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Person>(AppConfiguration);
            services.Configure<Person>(opt => { opt.Age = 33; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseMiddleware<PersonWiddleware>();

        }
    }
}
