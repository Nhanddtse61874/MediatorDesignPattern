using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityModel
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book").HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Author).IsRequired();

            builder.Property(x => x.Quantity).IsRequired();


            builder.HasMany(x => x.Items)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);
        }
    }
}
