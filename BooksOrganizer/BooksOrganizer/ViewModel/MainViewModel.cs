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

     //   private readonly IFrameNavigationService _navigationService;
        private readonly IDialogService _dialogService;


        #region MVVMLight property



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
        /// The <see cref="FrameUri" /> property's name.
        /// </summary>
        public const string FrameUriPropertyName = "FrameUri";

        private Uri _frameUri;

        /// <summary>
        /// Sets and gets the FrameUri property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Uri FrameUri
        {
            get
            {
                return _frameUri;
            }
            set
            {
                Set(FrameUriPropertyName, ref _frameUri, value);
                System.Diagnostics.Debug.WriteLine(_frameUri.ToString(), "_frameUri");
                System.Diagnostics.Debug.WriteLine(FrameUri.ToString(), "FrameUri");
            }
        }

        /// <summary>

        #endregion



        #region RelayComand
        public RelayCommand ShutdownCommand { get; private set; }

        public RelayCommand OpenMenuCommand { get; private set; }
        public RelayCommand CloseMenuCommand { get; private set; }

        #endregion


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, 
                             IDialogService dialogService/*,
                             IFrameNavigationService navigationService*/)
        {
           // _navigationService = navigationService;
            _dialogService = dialogService;

            FrameUri = ViewModelLocator.ListPageUri;


            if (IsInDesignMode)  
            {  
                // Code runs in Blend --> create design time data.  
            }  
         

            ShutdownCommand = new RelayCommand(ShutdownService.RequestShutdown);
            OpenMenuCommand = new RelayCommand(onOpenMenuCommand);
            CloseMenuCommand = new RelayCommand(onCloseMenuCommand);

        }
        #region exec command



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

        private Boolean CheckUri(Uri _frameUriToCheck, Uri _vmUri)
        {
            string StringUriToCheck = _frameUriToCheck.ToString();
            string StringUriVM = _vmUri.ToString();
            System.Diagnostics.Debug.WriteLine(StringUriToCheck, "StringUriToCheck");
            System.Diagnostics.Debug.WriteLine(StringUriVM, "StringUriVM");

            if (StringUriVM.Contains(StringUriToCheck))
            { return false; }
            else
            { return true; }
        }


        private RelayCommand _changeToListPage;

        /// <summary>
        /// Gets the ChangeToIntroPage.
        /// </summary>
        public RelayCommand ChangeToListPage
        {
            get
            {
                return _changeToListPage
                    ?? (_changeToListPage = new RelayCommand(
                    () =>
                    {
                        FrameUri = ViewModelLocator.ListPageUri;
                    },
                    () => CheckUri(FrameUri, ViewModelLocator.ListPageUri)));
            }
        }


        private RelayCommand _changeToSearchPage;

        /// <summary>
        /// Gets the ChangeToIntroPage.
        /// </summary>
        public RelayCommand ChangeToSearchPage
        {
            get
            {
                return _changeToSearchPage
                    ?? (_changeToSearchPage = new RelayCommand(
                    () =>
                    {
                        FrameUri = ViewModelLocator.SearchPageUri;
                    },
                    () => CheckUri(FrameUri, ViewModelLocator.SearchPageUri)));           
            }
        }



        private RelayCommand _changeToNewBookPage;

        /// <summary>
        /// Gets the ChangeToIntroPage.
        /// </summary>
        public RelayCommand ChangeToNewBookPage
        {
            get
            {
                return _changeToNewBookPage
                    ?? (_changeToNewBookPage = new RelayCommand(
                    () =>
                    {
                        FrameUri = ViewModelLocator.DetailPageUri;
                    },
                    () => CheckUri(FrameUri, ViewModelLocator.DetailPageUri)));
            }
        }




        private RelayCommand _changeToSettingsPage;

        /// <summary>
        /// Gets the ChangeToIntroPage.
        /// </summary>
        public RelayCommand ChangeToSettingsPage
        {
            get
            {
                return _changeToSettingsPage
                    ?? (_changeToSettingsPage = new RelayCommand(
                    () =>
                    {
                        FrameUri = ViewModelLocator.SettingsPageUri;
                    },
                    () => CheckUri(FrameUri, ViewModelLocator.SettingsPageUri)));
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