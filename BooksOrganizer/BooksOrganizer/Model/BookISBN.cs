using BooksOrganizer.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksOrganizer.Model
{
    public class BookISBN
    {
        [Key, Column(Order = 1)]
        public int BookId { get; set; }
        [Key, Column(Order = 2)]
        public int ISBNId { get; set; }

        public Book Book { get; set; }
        public ISBN ISBN { get; set; }
    }
}
