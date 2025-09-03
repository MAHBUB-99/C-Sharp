namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book(1, "1212", "C#", "Denis", "Programming", DateTime.Now, 10),
                new Book(2, "3434", "Java", "James", "Programming", DateTime.Now, 5),
                new Book(3, "5656", "Python", "Guido", "Programming", DateTime.Now, 7),
                new Book(4, "7878", "JavaScript", "Brendan", "Programming", DateTime.Now, 8),
                new Book(5, "9090", "Ruby", "Yukihiro", "Programming", DateTime.Now, 6),
                new Book(6, "1122", "HTML", "Tim", "Web Development", DateTime.Now, 12),
                new Book(7, "3344", "CSS", "Hakon", "Web Development", DateTime.Now, 9),
                new Book(8, "5566", "React", "Jordan", "Web Development", DateTime.Now, 11),
                new Book(9, "7788", "Angular", "Misko", "Web Development", DateTime.Now, 4),
                new Book(10, "9900", "Vue", "Evan", "Web Development", DateTime.Now, 3),
                new Book(11, "1213", "Data Science", "Andrew", "Data Analysis", DateTime.Now, 15),
                new Book(12, "3435", "Machine Learning", "Tom", "Data Analysis", DateTime.Now, 14),
                new Book(13, "5657", "Deep Learning", "Ian", "Data Analysis", DateTime.Now, 13),
                new Book(14, "7879", "AI", "Fei-Fei", "Data Analysis", DateTime.Now, 16),
                new Book(15, "9091", "Big Data", "Doug", "Data Analysis", DateTime.Now, 17)
            };

            var members = new List<Member>
            {
                MemberFactory.CreateMember(MemberType.student, 1, "Alice", "alice@mail.com", "01711111111"),
                MemberFactory.CreateMember(MemberType.teacher, 2, "Bob", "bob@mail.com", "01822222222"),
                MemberFactory.CreateMember(MemberType.guest,   3, "Charlie", "charlie@mail.com", "01933333333")
            };
            ILibraryService library = new LibraryService(books, members);
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("===== Library Management System =====");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. Member Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choose option: ");
                string roleChoice = Console.ReadLine();

                switch (roleChoice)
                {
                    case "1": // Admin Menu
                        AdminMenu(library);
                        break;
                    case "2": // Member Menu
                        MemberMenu(library);
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Exiting system... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // ========= Admin Menu =========
        static void AdminMenu(ILibraryService library)
        {
            bool adminRunning = true;
            while (adminRunning)
            {
                Console.Clear();
                Console.WriteLine("===== Admin Menu =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book (Not implemented yet)");
                Console.WriteLine("3. Add Member");
                Console.WriteLine("4. View Books");
                Console.WriteLine("5. View Members");
                Console.WriteLine("6. Back");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Book ID: ");
                        int bookId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter Category: ");
                        string category = Console.ReadLine();
                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Enter Copies: ");
                        int copies = int.Parse(Console.ReadLine());

                        library.AddBook(new Book(bookId, isbn, title, author, category, DateTime.Now, copies));
                        Console.WriteLine("Book added successfully!");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Write("Enter Member ID: ");
                        int memberId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter Phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Enter Type (student/teacher/guest): ");
                        string type = Console.ReadLine();

                        MemberType mType = Enum.Parse<MemberType>(type.ToLower());
                        var newMember = MemberFactory.CreateMember(mType, memberId, name, email, phone);
                        library.AddMember(newMember);

                        Console.WriteLine("Member added successfully!");
                        Console.ReadKey();
                        break;

                    case "4":
                        library.ShowBooks();
                        Console.ReadKey();
                        break;

                    case "5":
                        library.ShowMembers();
                        Console.ReadKey();
                        break;

                    case "6":
                        adminRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // ========= Member Menu =========
        static void MemberMenu(ILibraryService library)
        {
            Console.Write("Enter Member ID: ");
            int memberId = int.Parse(Console.ReadLine());

            bool memberRunning = true;
            while (memberRunning)
            {
                Console.Clear();
                Console.WriteLine("===== Member Menu =====");
                Console.WriteLine("1. Borrow Book");
                Console.WriteLine("2. Return Book");
                Console.WriteLine("3. Renew Book");
                Console.WriteLine("4. View Books");
                Console.WriteLine("5. View Members");
                Console.WriteLine("6. Back");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Book ID to borrow: ");
                        int borrowId = int.Parse(Console.ReadLine());
                        library.BorrowBook(memberId, borrowId);
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Write("Enter Book ID to return: ");
                        int returnId = int.Parse(Console.ReadLine());
                        library.ReturnBook(memberId, returnId);
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Write("Enter Book ID to renew: ");
                        int renewId = int.Parse(Console.ReadLine());
                        library.RenewBook(memberId, renewId);
                        Console.ReadKey();
                        break;

                    case "4":
                        library.ShowBooks();
                        Console.ReadKey();
                        break;

                    case "5":
                        library.ShowMembers();
                        Console.ReadKey();
                        break;

                    case "6":
                        memberRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
