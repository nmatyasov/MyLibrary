using System.Windows;

namespace BooksOrganizer.Helpers
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
