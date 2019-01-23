using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksOrganizer.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(256)]
        public string Path { get; set; }
        [MaxLength(256)]
        public string Url { get; set; }
        public int Pages { get; set; }
        public long FileSize { get; set; }
        public double Rate { get; set; }

        [MaxLength(8192)]
        public string Annonce { get; set; }

        [Column(TypeName = "blob")]
        public byte[] Cover { get; set; }
        public int PublishingYear { get; set; }
        public virtual ICollection<BookGenre> BookGenries { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookPublishier> BookPublisheirs { get; set; }
        public virtual ICollection<BookISBN> BookISBNs { get; set; }
    }
}