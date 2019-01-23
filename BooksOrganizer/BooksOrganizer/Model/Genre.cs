using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksOrganizer.Model
{
    [Table("Genries")]
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<BookGenre> BookGenries { get; set; }
    }
}
