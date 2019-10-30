using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Try_LazyLoad_EagerLoad.Models;
using Microsoft.OpenApi.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.IO;
using Try_LazyLoad_EagerLoad.Constants;

namespace Try_LazyLoad_EagerLoad
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
            services.AddControllers();
            services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApiDbContext")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApiDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dbContext.Database.Migrate();

            try
            {
                ExecuteSQL(ReadFile(SQL_FILE_PATH.SEED_DATA, env), serviceProvider);
            }
            catch (Exception) { }
        }

        private int ExecuteSQL(string sql, IServiceProvider serviceProvider)
        {
            int result = 0;

            using (System.Data.IDbConnection connection = new SqlConnection(Configuration.GetConnectionString("ApiDbContext")))
            {
                connection.Open();
                connection.Execute(sql);
            }
            return result;
        }

        private static string ReadFile(string path, IWebHostEnvironment hostingEnvironment)
        {
            var fileInfo = hostingEnvironment.ContentRootFileProvider.GetFileInfo(path);

            if (fileInfo.Exists)
            {
                return File.ReadAllText(fileInfo.PhysicalPath);
            }

            return string.Empty;
        }
    }
}
