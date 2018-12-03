using Microsoft.EntityFrameworkCore;


namespace BooksOrganizer.Model
{
  

    public class DataContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<ISBN> Isbn { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite("FileName = Books.db");
        }
    }
}
