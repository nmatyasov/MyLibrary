using System;
using BooksOrganizer.Model;
using System.Collections.ObjectModel;

namespace BooksOrganizer.Design
{
    public class DesignDataService : IDataService
    {


        public void GetData(Action<ObservableCollection<Book>, Exception> callback)
        { 
            throw new NotImplementedException();
            //ObservableCollection<Book> _books = new ObservableCollection<Book>();

            //callback(_books, null);
        }


    }
}