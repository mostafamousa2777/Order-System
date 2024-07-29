using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites.Identity;

namespace Taskk.Repository.Data
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRole(builder);
        }
        private static void SeedRole(ModelBuilder builder) {
            builder.Entity<IdentityRole>().HasData(

                new IdentityRole() { Name = "Admin", NormalizedName = "Admin", Id = "1" },
                new IdentityRole() { Name = "User", NormalizedName = "User", Id = "2" }

                ) ;
        
        
        }



    }
}
