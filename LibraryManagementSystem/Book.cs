using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime CollectionDate { get; set; }
        public int AvailableBooks { get; set; }

        public Book(DateTime collectionDate,int count)
        {
            this.CollectionDate = collectionDate;
            this.AvailableBooks = count;
        }

        public void Borrow()
        {
            Console.WriteLine("Borrowing Book");
        }

    }
}
