using System;
using System.Collections.Generic;

namespace list_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkingWithStrings();

            var fibonacciNumbers = new List<int> {1, 1};

            for(int i = fibonacciNumbers.Count; i < 20; i++) {
                var previous = fibonacciNumbers[fibonacciNumbers.Count -1];
                var previous2 = fibonacciNumbers[fibonacciNumbers.Count -2];

                fibonacciNumbers.Add(previous + previous2);
            }
            

            foreach (var item in fibonacciNumbers) {
                Console.WriteLine(item);
            }
        }

        static void WorkingWithStrings() {
            // create a list of strings
            var names = new List<string> {"Kenny", "Ana", "Felipe"};

            // loop over every item in the list
            foreach (var name in names) {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            // add into and remove from the list
            Console.WriteLine();
            names.Add("Maria");
            names.Add("Bill");
            names.Remove("Ana");
            foreach (var name in names) {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            // using indexes to access specific items in the list
            Console.WriteLine($"My name is {names[0]}");
            Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");

            // .Count can be used to count how much items are in a list
            Console.WriteLine($"The list has {names.Count} people in it");

            // finding out where a specific value is in a list
            var index = names.IndexOf("Felipe");
            if (index == -1) {
                Console.WriteLine($"When an item is not found, IndexOf returns {index}");
            } else {
                Console.WriteLine($"The name {names[index]} is at index {index}");
            }

            index = names.IndexOf("Not Found");
            if (index == -1) {
                Console.WriteLine($"When an item is not found, IndexOf returns {index}");
            } else {
                Console.WriteLine($"The name {names[index]} is at index {index}");
            }

            // sorting the list (alphabetically in the case of strings)
            names.Sort();
            foreach (var name in names) {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
        }
    }
}
