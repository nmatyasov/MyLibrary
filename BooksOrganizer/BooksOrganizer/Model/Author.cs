using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksOrganizer.Model
{
   public class Author
    {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int AuthorId { get; set; }
            [Required]
            [StringLength(255)]
            public string Name { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
