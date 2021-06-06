using Caco.API.Persistence.Contexts;
using Caco.API.Persistence.Repositories;
using Caco.API.Repositories;
using Caco.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Caco.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("board-api-in-memory");
            });

            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IColumnRepository, ColumnRepository>();
            services.AddScoped<IColumnService, ColumnService>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IChangeSet, ChangeSet>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));
            }
            else
            {

                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
