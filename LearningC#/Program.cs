namespace LearningC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(100, 1000);

            Console.WriteLine("You have 10 chance to guess:");
            int count = 1;
            while (count<=10)
            {
                Console.Write($"{count}th Guess : ");
                int guess = int.Parse(Console.ReadLine());
                if (guess == number)
                {
                    Console.WriteLine("Congratulation. You guess the correct number.");
                    return;
                }
                else if(guess < number)
                {
                    Console.WriteLine("Your guess is too low.");
                }
                else
                {
                    Console.WriteLine("Your guess is too high.");
                }
                count++;
            }
            Console.WriteLine("You are so close. Better luck for next time. Number was : "+ number);
        }

    }
}
