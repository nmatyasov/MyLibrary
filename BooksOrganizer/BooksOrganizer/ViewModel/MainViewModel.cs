using GalaSoft.MvvmLight;
using BooksOrganizer.Model;
using System.Data.Common;
using System.IO;
using System;
using System.Data.SQLite;
using GalaSoft.MvvmLight.Command;
using BooksOrganizer.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;

namespace BooksOrganizer.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private CollectionViewSource filtredCollection;

        #region MVVMLight property

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
        /// The <see cref="WindowState" /> property's name.
        /// </summary>
        public const string WindowStatePropertyName = "WindowState";

        private WindowState _windowState ;

        /// <summary>
        /// Sets and gets the WindowState property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public WindowState WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                Set(() => WindowState, ref _windowState, value, true);
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
        public byte[]  Cover
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

        public ICollectionView SourceCollection
        {
            get
            {
                return this.filtredCollection.View;
            }
        }


        /// <summary>
        /// The <see cref="IconKind" /> property's name.
        /// </summary>
        public const string IconKindPropertyName = "IconKind";

        private PackIconKind _iconKind;

        /// <summary>
        /// Sets and gets the IconKind property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public PackIconKind IconKind
        {
            get
            {
                return _iconKind;
            }
            set
            {
                Set(() => IconKind, ref _iconKind, value, true);
            }
        }


        #endregion


        #region RelayComand
        public RelayCommand ShutdownCommand { get; private set; }
        public RelayCommand MinimazeCommand { get; private set; }
        public RelayCommand ResizeCommand { get; private set; }
        
        #endregion


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
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


            if (IsInDesignModeStatic)
            {
                throw new NotImplementedException();
            }
            else
            {
   
            }

            ShutdownCommand = new RelayCommand(ShutdownService.RequestShutdown);
            MinimazeCommand = new RelayCommand(onMinimazeCommand);
            ResizeCommand = new RelayCommand(onResizeCommand);
           

            filtredCollection = new CollectionViewSource();
            filtredCollection.Source = BookList;
            filtredCollection.Filter += filterCollection_Filter;
            WindowState =  WindowState.Normal;
            IconKind = PackIconKind.WindowMaximize;
     
        }

        private RelayCommand<MouseButtonEventArgs> onMouseDownCommand;

        /// <summary>
        /// Gets the MouseDownCommand.
        /// </summary>
        public RelayCommand<MouseButtonEventArgs> MouseDownCommand
        {
            get
            {
                return onMouseDownCommand
                    ?? (onMouseDownCommand = new RelayCommand<MouseButtonEventArgs>(ExecuteMouseDownCommand));
            }
        }

        private void ExecuteMouseDownCommand(MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                if (e.ClickCount == 2)
                {
                    onResizeCommand();
                }
                else
                {
                    DragMoveService.RequestDragMove();
                }
        }

        private void onResizeCommand()
        {
            if ( WindowState == WindowState.Maximized)
                {
                IconKind = PackIconKind.WindowMaximize;
                WindowState = WindowState.Normal;
                }
            else {
                IconKind = PackIconKind.WindowRestore;
                WindowState = WindowState.Maximized;
            }
        }

        private void onMinimazeCommand()
        {
            WindowState = WindowState.Minimized;
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






        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}