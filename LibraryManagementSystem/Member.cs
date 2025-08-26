using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Member
    {
        public string Name { get; set; }
        public int MemberID { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime RenewalDate { get; set; }
        public void Register()
        {
            Console.WriteLine("Registering Member");
        }
    }
}
