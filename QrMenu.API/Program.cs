
using Microsoft.EntityFrameworkCore;
using QrMenu.Application.Interfaces;
using QrMenu.Application.Services;
using QrMenu.Infrastructure.Data;
using QrMenu.Infrastructure.Repository;

namespace QrMenu.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // PostgreSQL baðlantýsý
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

  
            // Dependency Injection
            builder.Services.AddScoped(typeof(IMenuRepository), typeof(MenuRepository));
            builder.Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            builder.Services.AddScoped<IMenuService, MenuService>();

            builder.Services.AddControllers().AddJsonOptions(options =>
                                            {
                                                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                                                options.JsonSerializerOptions.WriteIndented = true;
                                            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
