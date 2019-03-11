using BooksOrganizer.Helpers;
using BooksOrganizer.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace BooksOrganizer.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ListViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ListViewModel1 class.
        /// </summary>
        /// 

        private readonly IDataService _dataService;
        private CollectionViewSource filtredCollection;
        private readonly IDialogService _dialogService;

        #region RelayComand

        public RelayCommand ResetFilterCommand { get; private set; }

        #endregion



        /// <summary>
        /// The <see cref="BookList" /> property's name.
        /// </summary>
        public const string BookListPropertyName = "BookList";

        private ObservableCollection<Book> _booklist;

        /// <summary>
        /// Sets and gets the BookList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public ObservableCollection<Book> BookList
        {
            get
            {
                return _booklist;
            }

            set
            {
                if (_booklist == value)
                {
                    return;
                }

                var oldValue = _booklist;
                _booklist = value;
                RaisePropertyChanged(() => BookList, oldValue, value, true);
            }
        }

        /// <summary>
        /// The <see cref="Name" /> property's name.
        /// </summary>
        public const string NamePropertyName = "Name";

        private string _name = String.Empty;

        /// <summary>
        /// Sets and gets the Name property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                {
                    return;
                }

                var oldValue = _name;
                _name = value;
                RaisePropertyChanged(() => Name, oldValue, value, true);
            }
        }


        /// <summary>
        /// The <see cref="Author" /> property's name.
        /// </summary>
        public const string AuthorPropertyName = "Author";

        private string _author = String.Empty;

        /// <summary>
        /// Sets and gets the Author property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                if (_author == value)
                {
                    return;
                }

                var oldValue = _author;
                _author = value;
                RaisePropertyChanged(() => Author, oldValue, value, true);
            }
        }

        /// <summary>
        /// The <see cref="Cover" /> property's name.
        /// </summary>
        public const string CoverPropertyName = "Cover";

        private byte[] _cover = null;

        /// <summary>
        /// Sets and gets the Cover property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public byte[] Cover
        {
            get
            {
                return _cover;
            }

            set
            {
                if (_cover == value)
                {
                    return;
                }

                var oldValue = _cover;
                _cover = value;
                RaisePropertyChanged(() => Cover, oldValue, value, true);
            }
        }

        /// <summary>
        /// The <see cref="FilterText" /> property's name.
        /// </summary>
        public const string FilterTextPropertyName = "FilterText";

        private string _filterText = String.Empty;

        /// <summary>
        /// Sets and gets the FilterText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string FilterText
        {
            get
            {
                return _filterText;
            }

            set
            {
                if (_filterText == value)
                {
                    return;
                }

                var oldValue = _filterText;
                _filterText = value;
                this.filtredCollection.View.Refresh();
                RaisePropertyChanged(() => FilterText, oldValue, value, true);
            }
        }



        /// The <see cref="SelectedItem" /> property's name.
        /// </summary>
        public const string SelectedItemPropertyName = "SelectedItem";

        private Book _selectedItem;

        /// <summary>
        /// Sets and gets the SelectedItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public Book SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                if (_selectedItem == value)
                {
                    return;
                }

                var oldValue = _selectedItem;
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem, oldValue, value, true);
                Messenger.Default.Send<Book>(value);
            }
        }





        public ICollectionView SourceCollection
        {
            get
            {
                return this.filtredCollection.View;
            }
        }



        public ListViewModel(IDataService dataService,
                             IDialogService dialogService)
        {
     
            _dataService = dataService;
            _dialogService = dialogService;
            BookList = new ObservableCollection<Book>();
            _dataService.GetData(
                (items, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    BookList = items;
                });


            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.  
            }
            filtredCollection = new CollectionViewSource();
            filtredCollection.Source = BookList;
            filtredCollection.Filter += filterCollection_Filter;

            ResetFilterCommand = new RelayCommand(onResetFilterCommand);
        }


        private void onResetFilterCommand()
        {
            FilterText = String.Empty;
        }

        private void filterCollection_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            Book usr = e.Item as Book;
            if (usr.Name.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
    }
}