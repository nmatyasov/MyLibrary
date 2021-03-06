﻿using BooksOrganizer.Database;
using System;
using System.Collections.ObjectModel;
using System.Linq;

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

                if (!db.Books.Any())
                {
                    Seeds.Run();

                    foreach (var item in db.Books)
                    {
                        _books.Add(item);
                    }
                }

            }
            callback(_books, null);
        }
    }
}