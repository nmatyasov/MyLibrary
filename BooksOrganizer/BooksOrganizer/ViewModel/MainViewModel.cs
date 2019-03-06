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
        private readonly IFrameNavigationService _navigationService;
        private readonly IDialogService _dialogService;


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

        private WindowState _windowState = WindowState.Normal;

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

        private PackIconKind _iconKind = PackIconKind.WindowMaximize;

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


        /// <summary>
        /// The <see cref="OpenMenuVisible" /> property's name.
        /// </summary>
        public const string OpenMenuVisiblePropertyName = "OpenMenuVisible";

        private Visibility _openMenuVisible = Visibility.Visible;

        /// <summary>
        /// Sets and gets the OpenMenuVisible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public Visibility OpenMenuVisible
        {
            get
            {
                return _openMenuVisible;
            }

            set
            {
                if (_openMenuVisible == value)
                {
                    return;
                }

                var oldValue = _openMenuVisible;
                _openMenuVisible = value;
                RaisePropertyChanged(() => OpenMenuVisible, oldValue, value, true);
            }
        }


        /// <summary>
        /// The <see cref="CloseMenuVisible" /> property's name.
        /// </summary>
        public const string CloseMenuVisiblePropertyName = "CloseMenuVisible";

        private Visibility _closeMenuVisible = Visibility.Collapsed;

        /// <summary>
        /// Sets and gets the CloseMenuVisible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public Visibility CloseMenuVisible
        {
            get
            {
                return _closeMenuVisible;
            }

            set
            {
                if (_closeMenuVisible == value)
                {
                    return;
                }

                var oldValue = _closeMenuVisible;
                _closeMenuVisible = value;
                RaisePropertyChanged(() => CloseMenuVisible, oldValue, value, true);
            }
        }


        /// <summary>
        /// The <see cref="SelectedItem" /> property's name.
        /// </summary>
        public const string SelectedItemPropertyName = "SelectedItem";

        private Book _selectedItem ;

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
            }
        }


        #endregion


        #region RelayComand
        public RelayCommand ShutdownCommand { get; private set; }
        public RelayCommand MinimazeCommand { get; private set; }
        public RelayCommand ResizeCommand { get; private set; }
        public RelayCommand OpenMenuCommand { get; private set; }
        public RelayCommand CloseMenuCommand { get; private set; }
        public RelayCommand ResetFilterCommand { get; private set; }
        public RelayCommand ShowDetailBookCommand { get; private set; }
        public RelayCommand SearchBookCommand { get; private set; }

        public RelayCommand SettingsCommand { get; private set; }
        #endregion


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, 
                             IDialogService dialogService,
                             IFrameNavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
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
         

            ShutdownCommand = new RelayCommand(ShutdownService.RequestShutdown);
            MinimazeCommand = new RelayCommand(onMinimazeCommand);
            ResizeCommand = new RelayCommand(onResizeCommand);
            OpenMenuCommand = new RelayCommand(onOpenMenuCommand);
            CloseMenuCommand = new RelayCommand(onCloseMenuCommand);
            ResetFilterCommand = new RelayCommand(onResetFilterCommand);
            ShowDetailBookCommand = new RelayCommand(onShowDetailBookCommand);
            SearchBookCommand = new RelayCommand(onSearchBookCommand);
            SettingsCommand = new RelayCommand(onSettingsCommand);

            filtredCollection = new CollectionViewSource();
            filtredCollection.Source = BookList;
            filtredCollection.Filter += filterCollection_Filter;
   
        }
        #region exec command
        private void onSettingsCommand()
        {
            _navigationService.NavigateTo("SettingsPage");
        }

        private void onSearchBookCommand()
        {
            _navigationService.NavigateTo("SearchPage");
        }

        private void onShowDetailBookCommand()
        {
            _navigationService.NavigateTo("DetailPage", SelectedItem);
        }

        private void onResetFilterCommand()
        {
            FilterText = String.Empty;
        }

        private void onCloseMenuCommand()
        {
            CloseMenuVisible = Visibility.Collapsed;
            OpenMenuVisible = Visibility.Visible;
        }

        private void onOpenMenuCommand()
        {
            CloseMenuVisible = Visibility.Visible;
            OpenMenuVisible = Visibility.Collapsed;
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

        #endregion




        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}