using System.Collections.Generic;

namespace BooksOrganizer.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
        public int Pages { get; set; }
        public long Size { get; set; }
        public string Annonce { get; set; }
        public byte[] Title { get; set; }

        List<Author> Author { get; set; }
        List<Publisher> Publisher { get; set; }
        List<ISBN> ISBN { get; set; }
    }
}