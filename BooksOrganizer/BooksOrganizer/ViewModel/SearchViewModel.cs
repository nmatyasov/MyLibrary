using BooksOrganizer.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace BooksOrganizer.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SearchViewModel : ViewModelBase
    {
        public ObservableCollection<DataListItem> files { get; private set; }

        private object _filesLock = new object();
        private IFileService _fileService;

        /// <summary>
        /// Initializes a new instance of the SearchViewModel class.
        /// </summary>
        public SearchViewModel(IFileService fileService)
        {

            files = new ObservableCollection<DataListItem>();
            Messenger.Default.Register<DataListItem>(this, (item) => { files.Add(item); });
            BindingOperations.EnableCollectionSynchronization(files, _filesLock);

            _fileService = fileService;
        }
    }
}