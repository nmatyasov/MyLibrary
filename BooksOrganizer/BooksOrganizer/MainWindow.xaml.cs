using BooksOrganizer.Helpers;
using BooksOrganizer.View;
using BooksOrganizer.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using System.Windows;

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
            Messenger.Default.Register<OpenWindowMessage>(
            this,
            message => {
                if (message.Type == WindowType.wDetailDialog)
                {
                    var DetailWindowVM = SimpleIoc.Default.GetInstance<DetailViewModel>();
                    DetailWindowVM.SelectedBook = message.Argument;
                    var modalWindow = new DetailView() { DataContext = DetailWindowVM };
                    bool _result = modalWindow.ShowDialog() ?? false;
                    Messenger.Default.Send(_result ? "Accepted" : "Rejected");
                }
                else if (message.Type == WindowType.wSettingDialog) {
                    var SettingWindowVM = SimpleIoc.Default.GetInstance<SettingsViewModel>();
                    //  modalWindowVM.MyText = message.Argument;
                    var modalWindow = new SettingsView() { DataContext = SettingWindowVM };
                    bool _result = modalWindow.ShowDialog() ?? false;
                    Messenger.Default.Send(_result ? "Accepted" : "Rejected");
                }
                else if (message.Type == WindowType.wSearchDialog)
                {
                    var SettingWindowVM = SimpleIoc.Default.GetInstance<SearchViewModel>();
                    //  modalWindowVM.MyText = message.Argument;
                    var modalWindow = new SearchView() { DataContext = SettingWindowVM };
                    bool _result = modalWindow.ShowDialog() ?? false;
                    Messenger.Default.Send(_result ? "Accepted" : "Rejected");
                }
                /*  else
                  {
                      var uniqueKey = System.Guid.NewGuid().ToString();
                      var nonModalWindowVM = SimpleIoc.Default.GetInstance<NonModalWindowViewModel>(uniqueKey);
                      nonModalWindowVM.MyText = message.Argument;
                      var nonModalWindow = new NonModalWindow()
                      {
                          DataContext = nonModalWindowVM
                      };
                      nonModalWindow.Closed += (sender, args) => SimpleIoc.Default.Unregister(uniqueKey);
                      nonModalWindow.Show();
                  }*/
            });
        }

     
    }
}