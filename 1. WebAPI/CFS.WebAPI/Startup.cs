using AutoMapper;
using CFS.BusinessLogic.AutoMapper;
using CFS.BusinessLogic.BusinessLogic;
using CFS.BusinessLogic.IBusinessLogic;
using CFS.Data.Context;
using CFS.Data.IRepositories;
using CFS.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFS.WebAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins", builder =>
                                   {
                                       builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                   });
            });

            services.AddDbContext<CFSContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CFS.WebAPI", Version = "v1" });
            });

            #region Auto mapper Configuration

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DataMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            services.AddTransient<IAccountLogic, AccountLogic>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IProjectAllocationLogic, ProjectAllocationLogic>();
            services.AddTransient<IProjectAllocationRepository, ProjectAllocationRepository>();

            services.AddTransient<IEmpMonthlyHoursLogic, EmpMonthlyHoursLogic>();
            services.AddTransient<IEmpMonthlyHoursRepository, EmpMonthlyHoursRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{

            //}
            app.UseCors("_myAllowSpecificOrigins");
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CFS.WebAPI v1"));

            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint(swaggerJsonBasePath + "/swagger/v1/swagger.json", "CFS.WebAPI v1");
            });
            //app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
