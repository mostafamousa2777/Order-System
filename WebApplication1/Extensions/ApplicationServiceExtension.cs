using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Taskk.Core.Entites.Identity;
using Taskk.Core.Interfaces.Repos;
using Taskk.Core.Interfaces.Services;
using Taskk.Repository.Data;
using Taskk.Repository.Repos;
using Taskk.Services;

namespace WebApplication1.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection Services,IConfiguration configuration) {
            Services.AddDbContext<DataContext>(o => {

                o.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });
           Services.AddDbContext<IdentityDataContext>(o => {

                o.UseSqlServer(configuration.GetConnectionString("IdentitySqlConnection"));
            });

           Services
        .AddIdentity<ApplicationUser, IdentityRole>()
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<IdentityDataContext>();


            Services.AddScoped<ICustomerService, CustomerService>();
            Services.AddScoped<IOrderService, OrderService>();
            Services.AddScoped<IProductService, ProductService>();
            Services.AddScoped<IInvoiceService, InvoiceService>();



            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddAutoMapper(Assembly.GetExecutingAssembly());


            Services.AddControllers();
            Services.AddAuthentication(
                option => {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
                    
                    
                    
                    }





                );
         
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            return Services;
        }
    }
}
