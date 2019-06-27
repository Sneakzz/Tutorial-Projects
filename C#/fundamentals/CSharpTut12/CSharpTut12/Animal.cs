using System;

namespace CSharpTut12
{
    class Animal
    {
        public string Name { get; set; }

        public Animal(string name = "No Name")
        {
            this.Name = name;
        }

        // Anytime you need many overloaded methods that differ only by their
        // parameters, a generic is normally the solution
        public static void GetSum<T>(ref T num1, ref T num2)
        {
            double dblX = Convert.ToDouble(num1);
            double dblY = Convert.ToDouble(num2);
            Console.WriteLine($"{dblX} + {dblY} = {dblX + dblY}");
        }
    }
}
