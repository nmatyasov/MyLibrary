using BooksOrganizer.Model;
using System;
using System.Data.Entity;
using System.Data.SQLite;

namespace BooksOrganizer.Model
{

    public class DataContext : DbContext
    {

        public DataContext() : base(new SQLiteConnection()
   {
            ConnectionString =
                new SQLiteConnectionStringBuilder() { DataSource = @".\Database\books.db"  }
                .ConnectionString
                }, true)
            {
            }

            public DbSet<Book> Books { get; set; }
            public DbSet<Genre> Genries { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Publisher> Publishers { get; set; }
            public DbSet<ISBN> ISBNs { get; set; }
            public DbSet<BookGenre> BookGenries { get; set; }
            public DbSet<BookAuthor> BookAuthors { get; set; }
            public DbSet<BookPublishier> BookPublishiers { get; set; }
            public DbSet<BookISBN> BookISBNs { get; set; }
    }




}
