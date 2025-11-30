using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int Calculate(string s)
    {
        char[] chars = s.Where(c => c != ' ').ToArray();
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '+' || chars[i] == '-')
            {
                int a = chars[i + 1]-'0';   // FIXED: Convert char to int

                switch (chars[i])
                {
                    case '+':
                        stack.Push(stack.Pop() + a);
                        break;

                    case '-':
                        stack.Push(stack.Pop() - a);
                        break;
                }
                i++; // skip next digit
            }
            else
            {
                stack.Push(chars[i] - '0'); // convert digit to int
            }
        }
        return stack.Pop();
    }

    public static void Main(string[] args)
    {
        Solution sol = new Solution();

        // Sample test
        string input = "1+1";

        int result = sol.Calculate(input);
        Console.WriteLine("Result = " + result);
    }
}
