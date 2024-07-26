using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Taskk.Core.Interfaces.Repos;
using Taskk.Core.Interfaces.Services;
using Taskk.Repository.Data;
using Taskk.Repository.Repos;
using Taskk.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<DataContext>(o => {

                o.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
            });
            builder.Services.AddDbContext<IdentityDataContext>(o => {

                o.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySqlConnection"));
            });
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();



            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
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
