using BooksOrganizer.Model;

namespace BooksOrganizer.Helpers
{
    public class OpenWindowMessage
    {
        public WindowType Type { get; set; }
        public Book Argument { get; set; }
    }
}
