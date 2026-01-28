using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EduTrack.Utils
{
    internal class InputValidator
    {
        public static int GetValidInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Invalid Number. Try again.");
            }
        }
        public static int GetvalidRangeInt(string message,int min,int max)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value < max)
                    return value;
                Console.WriteLine($"Enter value between {min} and {max}.");

            }
        }
        public static long GetvalidPhone(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if(Regex.IsMatch(input,@"^\d{10}$"))
                    return Convert.ToInt64(input);
                Console.WriteLine("Enter Valid 10-digit phone number.");
            }
        }

        public static string GetvalidEmail(string message)
        {
            while (true)
            {
                Console.Write(message);
                string email = Console.ReadLine();
                if (email.Contains("@") && email.Contains("."))
                    return email;

                Console.WriteLine("Invalid email formate.");
            }
        }

        public static string GetNonEmptystring(string message)
        {

            while (true)
            {
                Console.Write(message);
                string value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
                Console.WriteLine("Value can Not be empty");
            }
        }

        public static int GetOptionalRangeInt(string message, int oldValue, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    return oldValue;

                if (int.TryParse(input, out int value) && value >= min && value <= max)
                    return value;

                Console.WriteLine($"Enter value between {min} and {max} or press Enter to keep old.");
            }
        }

        public static long GetOptionalPhone(string message, long oldValue)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    return oldValue;

                if (Regex.IsMatch(input, @"^\d{10}$"))
                    return Convert.ToInt64(input);

                Console.WriteLine("Enter valid 10-digit phone or press Enter to keep old.");
            }
        }

        public static string GetOptionalString(string message, string oldValue)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? oldValue : input;
        }

        public static string GetOptionalEmail(string message, string oldValue)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    return oldValue;

                if (input.Contains("@") && input.Contains("."))
                    return input;

                Console.WriteLine("Invalid email format. Try again or press Enter to keep old.");
            }
        }

    }
}
