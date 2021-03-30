using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASHC.DATA.Models;
using ASHC.REPOS;
using ASHC.REPOS.Interfaces.Category;
using ASHC.REPOS.Interfaces.CategoryType;
using ASHC.REPOS.Interfaces.User;
using ASHC.REPOS.Services.Category;
using ASHC.REPOS.Services.CategoryType;
using ASHC.REPOS.Services.User;
using ASHC.REPOS.UnitOfWorkInterface;
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

namespace ASHC.API
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
            //services.Configure<ApplicationSetting>(Configuration.GetSection("ApplicationSetting"));

            services.AddControllers();

            services.AddDbContext<db_ashcContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(REPOS.Interfaces.IRepository<>), typeof(REPOS.GenericRepository<>));
            services.AddScoped(typeof(IMUsers), typeof(UserService));
            services.AddScoped(typeof(ICategoryType), typeof(CategoryTypeService));
            services.AddScoped(typeof(ICategory), typeof(CategoryService));
            //services.AddScoped(typeof(IBulkRecords), typeof(BulkRecordService));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Arogya Seva Health Card API",
                    Version = "v2",
                    Description = "API Endpoints",
                });
            });

            services.AddCors(o => o.AddPolicy("TPPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("TPPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/V1/swagger.json", "PlaceInfo Services"));
        }
    }
}
