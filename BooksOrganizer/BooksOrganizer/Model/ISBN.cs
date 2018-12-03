using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksOrganizer.Model
{
    public class ISBN
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
