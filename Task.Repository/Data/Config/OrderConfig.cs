using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskk.Core.Entites;

namespace Taskk.Repository.Data.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
           builder.HasMany(o=>o.OrderItems).WithOne(I=>I.Order).HasForeignKey(o=>o.OrderId);
            builder.HasOne(o => o.Invoice).WithOne(In => In.Order).HasForeignKey<Invoice>(i => i.OrderId);
        }
    }
}
