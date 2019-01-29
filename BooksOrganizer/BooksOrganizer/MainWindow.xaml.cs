using System.Windows;
using BooksOrganizer.ViewModel;
using BooksOrganizer.Model;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Data.Entity;
using System.Linq;
using BooksOrganizer.Database;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using MaterialDesignThemes.Wpf;

namespace BooksOrganizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        /// 
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}