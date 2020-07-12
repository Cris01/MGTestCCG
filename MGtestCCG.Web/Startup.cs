using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using MGtestCCG.Domain.Entities;
using MGtestCCG.Domain.Irepositories;
using MGtestCCG.Domain.Services;
using MGtestCCG.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MGtestCCG.Web
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
            services.AddDbContext<EmployeeContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
            services.AddControllers();
            services.AddMediatR(Assembly.Load("MGtestCCG.Application.Query"), Assembly.GetExecutingAssembly(), Assembly.Load("MGtestCCG.Application.QueryHandler"));
            services.AddTransient(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            services.AddTransient(typeof(EmployeeServicePerHour));
            services.AddTransient(typeof(EmployeeServicePerMonth));
            services.AddTransient<Func<EmployeeContractType, IEmployeeService>>(serviceProvider => key =>
           {
               switch (key)
               {
                   case EmployeeContractType.PER_HOUR:
                       return serviceProvider.GetService<EmployeeServicePerHour>();
                   case EmployeeContractType.PER_MONTH:
                       return serviceProvider.GetService<EmployeeServicePerMonth>();
                   default:
                       throw new KeyNotFoundException();
               }
           });

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
        }

       
    }
}
