using GalaSoft.MvvmLight.Views;

namespace BooksOrganizer.Helpers
{
    public interface IFrameNavigationService : INavigationService
    {
        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        object Parameter { get; }
    }
}
