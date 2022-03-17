using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityModel
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();

            builder.Property(x => x.OrderId).IsRequired();

            builder.Property(x => x.BookId).IsRequired();

            builder.Property(x => x.Quantity).IsRequired();
        }
    }
}
