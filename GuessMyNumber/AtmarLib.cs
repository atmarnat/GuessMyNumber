//Some basic methods that I frequently use, that expand out on some existing functionality.
//Hopefully I can generalize enough to accomplish a variety of tasks.

using System;
using System.Linq;

namespace AtmarLib
{
    public class Check
    {
        //Checks if something is an int
        public static int Int()
        {
            int value = 0;
            bool exit = false;

            do
            {
                string userInput = Console.ReadLine();
                bool check = int.TryParse(userInput, out _);

                if (check == true)
                {
                    return value;
                }
                else
                {
                    Console.Write("Not a number, try again: ");
                }
            } while (exit == false);
            return value;
        }

        //Checks if something is inbetween 2 numbers
        public static int Int(int a, int b)
        {
            int value = 0;
            bool exit = false;

            do
            {
                string userInput = Console.ReadLine();
                bool check = int.TryParse(userInput, out _);

                if (check == true)
                {
                    value = int.Parse(userInput);
                    if (value >= a && value <= b)
                    {
                        exit = true;
                    }
                    else
                        Console.WriteLine("Out of range, try again: ");
                }
                else
                {
                    Console.Write("Not an integer, try again: ");
                }
            } while (exit == false);
            return value;
        }

        //checks if input equals whatever string you pass it
        public static string String(string[] arr)
        {
            string userInput;
            bool exit = false;

            do
            {
                userInput = Console.ReadLine().ToLower();

                if (arr.Any(userInput.Equals))
                {
                    exit = true;
                }
                else
                {
                    Console.Write("Invalid Choice, Try again: ");
                }
            } while (exit == false);
            return userInput;
        }
    }
}
