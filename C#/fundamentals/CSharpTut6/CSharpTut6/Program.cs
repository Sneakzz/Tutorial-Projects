using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut6
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Animal();
            Animal cat2 = new Animal("Whisky", "Meow");

            // Call the setter
            cat.SetName("Whiskers");

            // Set the property
            cat.Sound = "Meow";

            Console.WriteLine("The cat is named {0} and says {1}",
                cat.GetName(), cat.Sound);

            // Test auto generated getters and setters
            cat.Owner = "Kenny";

            Console.WriteLine("{0} owner is {1}",
                cat.GetName(), cat.Owner);

            // Get the read-only id number
            Console.WriteLine("{0} shelter id is {1}",
                cat.GetName(), cat.idNum);
            Console.WriteLine("{0} shelter id is {1}",
                cat2.GetName(), cat2.idNum);

            // Test static property
            Console.WriteLine("# of Animals : {0}",
                Animal.NumOfAnimals);

            Console.ReadLine();
        }
    }
}
