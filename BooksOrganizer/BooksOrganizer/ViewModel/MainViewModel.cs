using GalaSoft.MvvmLight;
using BooksOrganizer.Model;
using System.Data.Common;
using System.IO;
using System;
using System.Data.SQLite;
using GalaSoft.MvvmLight.Command;
using BooksOrganizer.Helpers;

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

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public RelayCommand ShutdownCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });

            if (IsInDesignModeStatic)
            {
                DbConnection connection = GetConnection("testDB");
            }
            else
            {
                 ShutdownCommand = new RelayCommand(ShutdownService.RequestShutdown);
            }
        }





        private DbConnection GetConnection(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".db3");
            DbConnection connection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", filePath));
            return connection;
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}