using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal abstract class Member
    {
        public int MemberID { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<BorrowTransaction> BorrowedBooks { get; set; }
        public decimal Fee { get; set; }
        public abstract int MaxBooksAllowed { get; }
        public abstract int MaxBorrowDays { get; }
        public abstract int DailyLateFee { get; }
        public abstract MemberType GetMemberType();


        protected Member(int memberID, string name, string email, string phoneNumber)
        {
            MemberID = memberID;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Fee = 0;
            BorrowedBooks = new List<BorrowTransaction>();
        }

        public bool CanBorrow => BorrowedBooks.Count < MaxBooksAllowed;
        public void AddFee(decimal fee) => Fee += fee;
        public override string ToString()
        {
            return $"[{MemberID}] | MemberType: ${GetMemberType()} | {Name} | Email: {Email} | Phone: {PhoneNumber} | Fee: ${Fee}";
        }
    }
}
