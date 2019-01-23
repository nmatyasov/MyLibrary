using System.Windows;
using BooksOrganizer.ViewModel;
using BooksOrganizer.Model;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Data.Entity;
using System.Linq;
using BooksOrganizer.Database;

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

        DataContext db;
        public ObservableCollection<BitmapImage> ImgList = new ObservableCollection<BitmapImage>();
        public MainWindow()
        {

            InitializeComponent();

            db = new DataContext();
            db.Books.Load();
            if (!db.Books.Any())
            {
                Seeds.Run();
            }

            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void ListViewMenu_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //UserControl usc = null;
            //GridMain.Children.Clear();

            //switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            //{
            //    case "ItemHome":
            //        usc = new UserControlHome();
            //        GridMain.Children.Add(usc);
            //        break;
            //    case "ItemCreate":
            //        usc = new UserControlCreate();
            //        GridMain.Children.Add(usc);
            //        break;
            //    default:
            //        break;
            //}
        }


        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
    }
}