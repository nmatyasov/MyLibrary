using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksOrganizer.Model
{
   public class Author
    {
        class Authors
        {
            public int Id { get; set; }
            public string Name { get; set; }

            List<Book> Book { get; set; }
        }


    }
}
