using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksOrganizer.Model
{
    [Table("BookPublishiers")]
    public class BookPublishier
    {
        [Key, Column(Order = 1)]
        public int BookId { get; set; }
        [Key, Column(Order = 2)]
        public int PublisherId { get; set; }

        public Book Book { get; set; }
        public Publisher Publisher { get; set; }
    }
}
