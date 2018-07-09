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
using RestWithAspNETUdemy.Repository;
using RestWithAspNETUdemy.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using RestWithAspNETUdemy.Business;
using RestWithAspNETUdemy.Business.Implementations;
using RestWithAspNETUdemy.Repository.Generic;

namespace RestWithAspNETUdemy
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        public int GenericRepositoryImpl { get; private set; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            Configuration = configuration;
            Environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //adding DB connections settings here - start
            var connectionString = Configuration["SqlConnection:SqlConnectionString"];
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(connectionString));
            //adding DB connections settings here - end

            if (Environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new System.Data.SqlClient.SqlConnection(connectionString);
                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database Migration failed", ex);
                    throw;
                }
            }

            services.AddMvc();
            services.AddApiVersioning();
            //dependency injection -- Add all services here, then, add a ref of the service into the controller - start
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IBookBusiness, BookBusinessImpl>();

            //services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
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
