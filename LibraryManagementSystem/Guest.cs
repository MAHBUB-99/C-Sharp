using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Guest : Member
    {
        public Guest(int memberId, string name, string email, string phoneNumber) : base(memberId, name, email, phoneNumber)
        {
        }
        public override int MaxBooksAllowed => 1;
        public override int MaxBorrowDays => 7;
        public override int DailyLateFee => 3;
        public override MemberType GetMemberType() => MemberType.guest;
    }
}
