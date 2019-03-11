using System;
using System.Windows.Navigation;

namespace BooksOrganizer.Helpers
{
    public interface INavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Uri uri);
        void GoBack();
    }
}