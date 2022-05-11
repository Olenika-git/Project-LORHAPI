<<<<<<< HEAD
using LORHAPI_API.Data;
=======
<<<<<<< HEAD
=======
using LORHAPI_API.Data;
>>>>>>> b2534f9 (MAJ)
>>>>>>> 54bb923 (Debut)
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
<<<<<<< HEAD
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> b2534f9 (MAJ)
>>>>>>> 54bb923 (Debut)
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LORHAPI_API
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
<<<<<<< HEAD
            services.AddDbContext<Db_Context>(options => //ajout pour accès BDD
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
=======
<<<<<<< HEAD
=======
            services.AddDbContext<Db_Context>(options => //ajout pour accès BDD
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
>>>>>>> b2534f9 (MAJ)
>>>>>>> 54bb923 (Debut)
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LORHAPI_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LORHAPI_API v1"));
            }

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
