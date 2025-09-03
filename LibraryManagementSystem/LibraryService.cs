using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class LibraryService : ILibraryService
    {
        private readonly List<Book> books;
        private readonly List<Member> members;
        public LibraryService(List<Book> book,List<Member>member)
        {
            books = new List<Book>(book);
            members = new List<Member>(member);
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void AddMember(Member member)
        {
            members.Add(member);
        }
        public void RemoveBook(int bookID)
        {
            var book = books.FirstOrDefault(b => b.BookID == bookID);
            if(book != null)
            {
                books.Remove(book);
            }
        }
        public void RemoveMember(int memberID)
        {
            var member = members.FirstOrDefault(m => m.MemberID == memberID);
            if (member != null)
            {
                members.Remove(member);
            }
        }

        public void BorrowBook(int bookID, int memberID)
        {
            var book = books.FirstOrDefault(b => b.BookID == bookID);
            var member = members.FirstOrDefault(m => m.MemberID == memberID);
            if(member == null || book == null)
            {
                Console.WriteLine("Invalid Bember or Book.");
                return;
            }
            if(!book.lendBook())
            {
                Console.WriteLine("Book is not available.");
                return;
            }
            if(!member.CanBorrow)
            {
                Console.WriteLine("Borrow Limit Reached.");
                return;
            }

            var transaction = new BorrowTransaction(member, book);
            member.BorrowedBooks.Add(transaction);
            Console.WriteLine($"Book '{book.Title}' lent to member '{member.Name}'. Due on {transaction.DueDate.ToShortDateString()}");
        }

        public void ReturnBook(int bookID, int memberID)
        {
            var book = books.FirstOrDefault(b => b.BookID == bookID);
            var member = members.FirstOrDefault(m => m.MemberID == memberID);
            if (member == null || book == null)
            {
                Console.WriteLine("Invalid Bember or Book.");
                return;
            }
            var transaction = member.BorrowedBooks.FirstOrDefault(t => t.BorrowedBook.BookID == bookID && !t.IsReturned);
            if(transaction == null)
            {
                Console.WriteLine("No such borrow transaction found.");
                return;
            }
            transaction.ReturnBook(DateTime.Now);
            book.returnBook();
            Console.WriteLine($"Book '{book.Title}' returned by member '{member.Name}'.");
            if(transaction.CalculateLateFee() > 0)
            {
                Console.WriteLine($"Late fee incurred: ${transaction.CalculateLateFee()}");
            }
        }

        public void RenewBook(int bookID, int memberID)
        {
            var member = members.FirstOrDefault(m => m.MemberID == memberID);
            var transaction = member?.BorrowedBooks.FirstOrDefault(t=>t.BorrowedBook.BookID == bookID && t.ReturnDate == null);
            if (transaction == null) { Console.WriteLine("No active borrow found."); return; }
            transaction.Renew();
            Console.WriteLine($"{transaction.BorrowedBook.Title} renewed. New due date: {transaction.DueDate.ToShortDateString()}");
        }

        public void ShowBooks()
        {
            Console.WriteLine("\nBooks:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        public void ShowMembers()
        {
            Console.WriteLine("\nMembers:");
            foreach(var member in members)
            {
                Console.WriteLine(member);
            }
        }

    }
}
