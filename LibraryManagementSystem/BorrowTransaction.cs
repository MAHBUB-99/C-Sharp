using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class BorrowTransaction
    {
        //public int TransactionID { get; }
        public Member Borrower { get; set; }
        public Book BorrowedBook { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned => ReturnDate.HasValue;
        public BorrowTransaction(Member borrower, Book borrowedBook)
        {
            //TransactionID = transactionID;
            Borrower = borrower;
            BorrowedBook = borrowedBook;
            BorrowDate = DateTime.Now;
            DueDate = BorrowDate.AddDays(borrower.MaxBorrowDays);
            ReturnDate = null;
        }

        public void ReturnBook(DateTime returnDate)
        {
            ReturnDate = returnDate;
            if (returnDate > DueDate)
            {
                decimal fee = CalculateLateFee();
                Borrower.AddFee(fee);
            }
        }
        public decimal CalculateLateFee()
        {
            if (!IsReturned || ReturnDate <= DueDate)
            {
                return 0;
            }
            int lateDays = (ReturnDate.Value - DueDate).Days;
            return lateDays * Borrower.DailyLateFee;
        }
        public void Renew()
        {
            DueDate = DueDate.AddDays(Borrower.MaxBorrowDays);
        }
        public override string ToString()
        {
            string status = IsReturned ? $"Returned on {ReturnDate.Value.ToShortDateString()}" : $"Due on {DueDate.ToShortDateString()}";
            return $"[TransactionID: ] | Book: {BorrowedBook.Title} | Borrower: {Borrower.Name} | Borrowed on: {BorrowDate.ToShortDateString()} | {status}";
        }
    }
}
