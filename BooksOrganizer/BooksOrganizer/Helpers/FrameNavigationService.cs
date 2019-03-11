
///http://qaru.site/questions/414985/mvvm-light-50-how-to-use-the-navigation-service
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace BooksOrganizer.Helpers
{
    public class NavigationService : INavigationService, INotifyPropertyChanged
    {
        private readonly Dictionary<string, Uri> _pagesByKey;
        private readonly List<string> _historic;
        private Frame _mainFrame;

        public event NavigatingCancelEventHandler Navigating;
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService"/> class.
        /// </summary>
        public NavigationService()
        {
            _pagesByKey = new Dictionary<string, Uri>();
            _historic = new List<string>();
        }
        /// <summary>
        /// Gets the key corresponding to the currently displayed page.
        /// </summary>
        /// <value>
        /// The current page key.
        /// </value>
        public string CurrentPageKey
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        /// 

        public object Parameter { get; private set; }

        /// <summary>
        /// The go back.
        /// </summary>
        public void GoBack()
        {
            if (EnsureMainFrame()
                && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }


        /// <summary>
        /// The navigate to.
        /// </summary>
        /// <param name="pageKey">
        /// The page key.
        /// </param>
        public void NavigateTo(Uri pageUri)
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(pageUri);
            }
        }



        public void NavigateTo(Uri pageUri, object parameter)
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(pageUri);

                Parameter = parameter;
            }
        }



        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            //_mainFrame = Application.Current.MainWindow.FindName("MainFrameDS") as Frame;
            // used this link:  https://stackoverflow.com/questions/2216917/wpf-equivalent-to-silverlight-rootvisual
            _mainFrame = LogicalTreeHelper.FindLogicalNode(Application.Current.MainWindow, "ContentFrame") as Frame;

            if (_mainFrame != null)
            {
                // Could be null if the app runs inside a design tool
                _mainFrame.Navigating += (s, e) =>
                {
                    if (Navigating != null)
                    {
                        Navigating(s, e);
                    }
                };
                return true;
            }
            return false;
        }




        /// <summary>
        /// Gets the name of the descendant from.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="name">The name.</param>
        /// <returns>The FrameworkElement.</returns>
        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
