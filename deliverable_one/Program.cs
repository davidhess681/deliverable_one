using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deliverable_one
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intro statement, giving the user instruction.
            Console.WriteLine("Welcome to David's Math Challenge!");
            Console.WriteLine("Please give me two integers with the same number of digits, and I will calculate if each corresponding place sums to the same total.");
            Console.WriteLine("Ex: If first number is 523 and second number is 476, then I will say yes because 5+4 = 2+7 = 3+6.");
            Console.WriteLine("Don't try to break me! I will know if your inputs are invalid!");
            Console.WriteLine("");

            // Ask the user for their first number.
            Console.WriteLine("Please type your first number, then press enter:");
            // Check to see if the user's input can be converted to int32 format. If not, give the user another try.
            string s1 = Console.ReadLine();
            while (!int.TryParse(s1, out int result))
            {
                Console.WriteLine("Your number is too big or is not an integer. Try again:");
                s1 = Console.ReadLine();
            }
            // Assign the user's input to the variable "number1".
            int number1 = Convert.ToInt32(s1);

            // Same process as above, but for the user's second number.
            Console.WriteLine("Now for your second number:");
            string s2 = Console.ReadLine();
            while (!int.TryParse(s2, out int result))
            {
                Console.WriteLine("Your number is too big or is not an integer. Try again:");
                s2 = Console.ReadLine();
            }
            int number2 = Convert.ToInt32(s2);

            /* Check to see if both numbers are the same length. If not, tell user the numbers aren't the same length, then finish. 
            (Ideally the program should have a reset function to start from the beginning in this situation.) */
            int num1length = number1.ToString().Length;
            int num2length = number2.ToString().Length;
            if (num1length != num2length)
            {
                Console.WriteLine("Your numbers aren't the same length!");
            }
            else
            {

                // Repeats to the user which numbers have been chosen.
                Console.WriteLine("");
                Console.WriteLine("Your numbers are " + number1 + " and " + number2);

                // Run Task(). Tells user whether or not the corresponding digits sum to the same total.
                bool answer = Task(number1, number2);
                switch (answer)
                {
                    case true:
                        Console.WriteLine("YES! The corresponding digits have the same total!");
                        break;

                    case false:
                        Console.WriteLine("No, the corresponding digits do NOT have the same total!");
                        break;

                    default:
                        Console.WriteLine("Looks like your inputs are invalid! Sorry!");
                        break;

                }
            }

            // End of the program. Prompts the user to press any key to close.
            Console.WriteLine("");
            Console.WriteLine("Thank you for playing! Press any key to close.");
            Console.ReadKey();
        }
        

        static bool Task(int number1, int number2)
        {
            // Converts number 1 into an array containing its digits; same with number 2. Thanks to Stack overflow for this!
            int[] digits1 = number1.ToString().Select(o => Convert.ToInt32(o)).ToArray();
            int[] digits2 = number2.ToString().Select(o => Convert.ToInt32(o)).ToArray();

            // Add together the first digit in both numbers and store it as a variable.
            int firstDigits = digits1[0] + digits2[0];

            // Add together the "i"th digit in both numbers for all remaining digits and compare it to our variable "firstDigits".
            for (int i = 0; i < digits1.Length; i++)
            {
                if (firstDigits != digits1[i] + digits2[i])
                {
                    // If at any point the total does not match the total of the first digits, then we return false and end the task.
                    return false;
                }
                else
                {

                }
            }

            // If the above operation never returns false, then we return true and end the task.
            return true;
        }
        
    }
}
