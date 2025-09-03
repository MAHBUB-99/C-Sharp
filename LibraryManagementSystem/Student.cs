using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Student : Member
    {
        public Student(int memberId,string name,string email, string phoneNumber) : base(memberId, name, email, phoneNumber)
        {
        }
        public override int MaxBooksAllowed => 3;
        public override int MaxBorrowDays => 14;
        public override int DailyLateFee => 2;
        public override MemberType GetMemberType() => MemberType.student;
    }
}
