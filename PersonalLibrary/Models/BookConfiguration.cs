using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonalLibrary.Models
{
  public class BookConfiguration : IEntityTypeConfiguration<Book>
  {
    public void Configure(EntityTypeBuilder<Book> builder)
    {
      builder.ToTable("Books");

      builder.Property(e => e.TitleOfTheBook)
             .HasColumnName("Title Of The Book");

      builder.Property(e => e.YearOfPublishing)
             .HasMaxLength(4)
             .HasColumnName("The Year Of Publishing");

      builder.Property(e => e.Category)
             .HasColumnName("Book's Category");

      builder.Property(u => u.CreatedAt)
             .HasColumnName("Date Of Creation")
             .HasColumnType("datetime")
             .HasComputedColumnSql("GETDATE()");
    }
  }
}
