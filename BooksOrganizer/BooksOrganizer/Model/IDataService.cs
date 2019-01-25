using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BooksOrganizer.Model
{
    public interface IDataService
    {
        void GetData(Action<ObservableCollection<Book>, Exception> callback);
    }
}
