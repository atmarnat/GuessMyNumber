﻿using System;
using System.Collections;
using System.Collections.Generic;
using AtmarLib;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GuessMyNumber Project");
            //Bisection algorithm
            List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int choice = Check.Int(1, 10);
            Bisection(choice, arr);

            Console.WriteLine("Are you ready to play?");
            Console.ReadKey();
            Console.Clear();
            //Guess my number, human plays
            
            int hCount = 0;
            int hTotal = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Round {i + 1}");
                hTotal += HumanGuessing();
                hCount++;
            }

            //Guess my number, computer plays
            int cCount = 0;
            int cTotal = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nRound {i + 1}");
                cTotal += CompGuessing();
                cCount++;
            }

            //Averages
            //Console.WriteLine($"The average number of guesses for human guessing = {hTotal / hCount}");
            Console.WriteLine($"The average number of guesses for computer guessing = {cTotal / cCount}");
        }

        //bisection Algorithm
        static List<int> Bisection(int choice, List<int> arr)
        {
            int mid = arr[((arr.Count) / 2)-1];
            PrintInfo(mid, arr);

            if (mid == choice)
            {
                Console.WriteLine($"The value, {mid}, has been found.");
                return arr;
            }

            else if (choice > arr[mid])
            {
                
                arr.RemoveRange(0, arr.Count - mid);
                arr = Bisection(choice, arr);
            }

            else if (choice < arr[mid])
            {
                arr.RemoveRange(mid, arr.Count - mid);
                arr = Bisection(choice, arr);
            }

            return arr;
        }
        static void PrintInfo(int mid, List<int> arr)
        {
            Console.WriteLine($"The middle value is now {mid}");
            Console.Write("The list is now set to {");
            for(int i = 0; i < arr.Count - 1; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine(arr[arr.Count - 1] + "}");
        }

        static int HumanGuessing()
        {
            int low = 1;
            int high = 1000;
            bool exit = false;
            List<String> choices = new List<String>();

            Random r = new Random();
            int answer = r.Next(low, high);

            Console.Write("Guess a number between 1-1000: ");
            int guess = AtmarLib.Check.Int(low, high);
            choices.Add(guess.ToString());
            while (exit == false)
            {
                Console.Write("\nYour Guesses so far: ");
                choices.ForEach(item => Console.Write(item + " "));

                if (guess > answer)
                {
                    choices.Add("^");
                    Console.WriteLine("\nYour guess was too high.");
                    Console.Write("Guess a number between 1-1000: ");
                    guess = AtmarLib.Check.Int(low, high);
                    choices.Add(guess.ToString());
                }
                if (guess < answer)
                {
                    choices.Add("v");
                    Console.WriteLine("\nYour guess was too low.");
                    Console.Write("Guess a number between 1-1000: ");
                    guess = AtmarLib.Check.Int(low, high);
                    choices.Add(guess.ToString());
                }
                if (answer == guess)
                {
                    Console.WriteLine("You guessed the number!");
                    exit = true;
                }
            }
            Console.WriteLine(choices.Count);
            return choices.Count;
        }
        static int CompGuessing()
        {
            int min = 1; int max = 100; int mid = 50;
            int count = 0;
            string[] str = new string[] { "too high", "too low", "correct" };
            string choice;
            bool exit = false;
            List<int> choices = new List<int>();

            Console.WriteLine("Think of a number between 1-100, I will try to guess it.");
            Console.WriteLine("Press [Enter] to start");
            Console.ReadKey();
            while (exit == false)
            {
                Console.WriteLine($"\nMy guess is: {mid}");
                Console.Write("too high/too low/correct? : ");
                choice = AtmarLib.Check.String(str);
                count++;
                choices.Add(mid);

                Console.Write("\nMy Guesses so far: ");
                choices.ForEach(item => Console.Write(item + " "));

                if (choice == "too high")
                {
                    max = mid;
                    mid = (max + min) / 2;
                }
                if (choice == "too low")
                {
                    min = mid;
                    mid = (max + min) / 2;
                    if (min == 99)
                    {
                        mid = 100;
                    }
                }
                if (choice == "correct")
                {
                    exit = true;
                    break;
                }
            }

            return count;
        }
    }
}