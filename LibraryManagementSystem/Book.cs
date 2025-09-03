using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Book
    {
        public int BookID { get; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime CollectionDate { get; set; }
        public int CopiesTotal { get; set; }
        public int AvailableBooks { get; set; }
        public Book(int bookID, string isbn, string title, string author, string category, DateTime collectionDate,int copies)
        {
            if(copies < 0)
            {
                throw new ArgumentException("Copies cannot be negative");
            }
            BookID = bookID;
            Isbn = isbn;
            Title = title;
            Author = author;
            Category = category;
            CollectionDate = collectionDate;
            CopiesTotal = copies;
            AvailableBooks = copies;
        }

        public bool lendBook()
        {
            if (AvailableBooks <= 0)
            {
                return false;
            }
            AvailableBooks--;
            return true;
        }
        public void returnBook()
        {
            if(AvailableBooks < CopiesTotal)
            {
                AvailableBooks++;
            }
        }
        public override string ToString()
        {
            return $"[{BookID}] {Title} by {Author} | Available: {AvailableBooks}/{CopiesTotal}";
        }
    }
}
