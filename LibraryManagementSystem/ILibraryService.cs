using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal interface ILibraryService
    {
        void AddBook(Book book);
        void AddMember(Member member);
        void RemoveBook(int bookID);
        void RemoveMember(int memberID);
        void BorrowBook(int bookID, int memberID);
        void ReturnBook(int bookID, int memberID);
        void RenewBook(int bookID, int memberID);
        void ShowBooks();
        void ShowMembers();
        //void ShowLentBooks();
        //void ShowOverdueBooks();
    }
}
