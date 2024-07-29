using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Taskk.Core.Interfaces.Repos;
using Taskk.Core.Interfaces.Services;
using Taskk.Repository.Data;
using Taskk.Repository.Repos;
using Taskk.Services;
using WebApplication1.Extensions;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

          


            builder.Services.AddAplicationService(builder.Configuration);

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
