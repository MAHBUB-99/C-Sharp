using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Teacher : Member
    {
        public Teacher(int memberId, string name, string email, string phoneNumber) : base(memberId, name, email, phoneNumber)
        {
        }
        public override int MaxBooksAllowed => 5;
        public override int MaxBorrowDays => 30;
        public override int DailyLateFee => 1;
        public override MemberType GetMemberType() => MemberType.teacher;
    }
}
