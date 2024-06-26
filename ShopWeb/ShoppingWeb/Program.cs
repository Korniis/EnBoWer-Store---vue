using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using ShoppingWeb.Data;
using ShoppingWeb.Helpers;
using ShoppingWeb.Services.Implmentation;
using ShoppingWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "使用Bearer方案的JWT授权报头",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddScoped<MyDbContext>();
            builder.Services.AddDbContext<MyDbContext>(option =>
            {
                var serverVersion = new MySqlServerVersion(new Version(5, 5, 0));
                option.UseMySql(builder.Configuration.GetConnectionString("Shopconn"), serverVersion);
            });

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("cors", p =>
                {
                    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection(nameof(AuthSettings)));
            builder.Services.AddScoped<IUserService,UserService>();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          

            app.UseHttpsRedirection();
            app.UseCors("cors"); 
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthorization();
           
            app.MapControllers();
            app.Run();
        }
    }
}
