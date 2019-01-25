using System;
using System.Collections.ObjectModel;

namespace BooksOrganizer.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<ObservableCollection<Book>, Exception> callback)
        {

            ObservableCollection<Book> _books = new ObservableCollection<Book>();
            using (DataContext db = new DataContext())
            {

                foreach (var item in db.Books)
                {
                    _books.Add(item);
                }

            }
            callback(_books, null);
        }
    }
}