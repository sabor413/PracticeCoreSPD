using System.Collections.Generic;

namespace PracticeCoreSPD.Areas.Facade.Core
{
    public class PriceComparer
    {
        public List<Book> Compare(string isbn)
        {
            ServiceAClient clientA = new ServiceAClient();
            Book bookA = clientA.SearchBook(isbn);

            ServiceBClient clientB = new ServiceBClient();
            Book bookB = clientB.SearchBook(isbn);

            List<Book> books = new List<Book> {bookA, bookB};

            books.Sort((b1, b2) => b1.Price.CompareTo(b2.Price));

            return books;

        }
    }
}
