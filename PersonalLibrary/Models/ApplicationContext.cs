using Microsoft.EntityFrameworkCore;

namespace PersonalLibrary.Models
{
  public class ApplicationContext : DbContext
  {
    // DbContext: определяет контекст данных, используемый для взаимодействия с базой данных
    // DbSet/DbSet<TEntity>: представляет набор объектов, которые хранятся в базе данных
    // DbContextOptionsBuilder: устанавливает параметры подключения
    public virtual DbSet<Book> Books { get; set; }

    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
      optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PersonalLibraryDB;Trusted_Connection=True;");
    // Подключение Fluent API - набора методов, которые определяют сопоставление между классами и их свойствами и таблицами и их столбцами
    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
      modelBuilder.ApplyConfiguration(new BookConfiguration());
  }
}
