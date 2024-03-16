using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingWeb.Data;

namespace ShoppingWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<MyDbContext>();
            builder.Services.AddDbContext<MyDbContext>(option => {
                var serverVersion = new MySqlServerVersion(new Version(5, 5, 0));
                option.UseMySql(builder.Configuration.GetConnectionString("Shopconn"), serverVersion);
            
            }
            
            
            );
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