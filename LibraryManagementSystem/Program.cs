namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Class :  Book, Member, Librarian
            Book book = new Book(DateTime.Now,10);
            book.Title = "C#";
            book.Author = "Mahbub";
            book.Category = "Programming";
        }
    }
}
