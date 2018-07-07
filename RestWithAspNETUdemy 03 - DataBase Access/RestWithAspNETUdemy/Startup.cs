using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestWithAspNETUdemy.Model.Context;
using RestWithAspNETUdemy.Services;
using RestWithAspNETUdemy.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace RestWithAspNETUdemy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //adding DB connections settings here - start
            var connection = Configuration["SqlConnection:SqlConnectionString"];
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection));
            //adding DB connections settings here - end

            services.AddMvc();

            //dependency injection -- Add all services here, then, add a ref of the service into the controller - start
            services.AddScoped<IPersonService, PersonServiceImpl>();
            //dependency injection -- Add all services here, then, add a ref of the service into the controller - end
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
