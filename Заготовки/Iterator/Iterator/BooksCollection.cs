using System.Collections.Generic;

namespace Iterator
{
    public class BooksCollection : IBooksEnumarable
    {
        protected List<string> BooksList = new List<string>();

        public void AddBook(string bookName)
        {
            BooksList.Add(bookName);
        }

        public IBooksEnumerator GetEnumerator()
        {
            return new BookEnumerator(BooksList);
        }
    }
}
