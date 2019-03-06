namespace BooksOrganizer.Model
{
    public class DataItem
    {
        private string filter;
        private bool includeSubs;

        public string Title
        {
            get;
            private set;
        }

        public DataItem(string title)
        {
            Title = title;
        }

        public DataItem(string title, string filter, bool includeSubs) : this(title)
        {
            this.filter = filter;
            this.includeSubs = includeSubs;
        }
    }
}