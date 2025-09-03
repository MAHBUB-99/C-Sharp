using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal static class MemberFactory
    {
        public static Member CreateMember(MemberType memberType, int memberID, string name, string email, string phoneNumber)
        {
            return memberType switch
            {
                MemberType.student => new Student(memberID, name, email, phoneNumber),
                MemberType.teacher => new Teacher(memberID, name, email, phoneNumber),
                MemberType.guest => new Guest(memberID, name, email, phoneNumber),
                _ => throw new ArgumentException("Invalid member type"),
            };
        }
    }
}
