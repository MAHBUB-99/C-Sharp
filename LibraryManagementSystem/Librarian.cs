using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Librarian
    {
        public string Name { get; set; }
        public int EmployeeID { get; set; }
        public DateTime HireDate { get; set; }
        public string position { get; set; }
        public void ManageInventory()
        {
            Console.WriteLine("Managing the inventory!");
        }
    }
}
