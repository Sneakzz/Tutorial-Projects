using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTut15
{
    // Language Integrated Query (LINQ) provides many tools for working with data.
    // LINQ is similar to SQL, but it can work with data aside from databases.
    // You manipulate data using Query Expressions

    class Program
    {
        static void Main(string[] args)
        {
            QueryStringArray();

            // Get the array returned and print it
            int[] intArray = QueryIntArray();

            foreach (int i in intArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            QueryArrayList();

            QueryCollection();

            QueryAnimalData();

            Console.ReadLine();
        }

        static void QueryStringArray()
        {
            string[] dogs = { "K 9", "Brian Griffin",
            "Scooby Doo", "Old Yeller", "Rin Tin Tin",
            "Benji", "Charlie B. Barkin", "Lassie",
            "Snoopy" };

            // Get strings with spaces and put in alphabetical order.

            // The "from" keyword states where data comes from and where to store
            // each piece as you cycle.

            // The "where" keyword defines conditions that must be met.

            // The "orderby" keyword defines what data is used for 
            // ordering results (ascending / descending).

            // The "select" keyword defines the variable that is checked against the condition.
            var dogSpaces = from dog in dogs
                            where dog.Contains(" ")
                            orderby dog descending
                            select dog;

            foreach (var i in dogSpaces)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

        static int[] QueryIntArray()
        {
            int[] nums = { 5, 10, 15, 20, 25, 30, 35 };

            // Get numbers bigger than 20
            var gt20 = from num in nums
                       where num > 20
                       orderby num
                       select num;

            foreach (var i in gt20)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // The type is an enumerable
            Console.WriteLine($"Get Type : {gt20.GetType()}");

            // You can convert it into a List or array
            var listGT20 = gt20.ToList<int>();
            var arrayGT20 = gt20.ToArray();

            // If you change the data the query automatically updates.
            nums[0] = 40;

            foreach (var i in gt20)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            return arrayGT20;
        }

        static void QueryArrayList()
        {
            ArrayList famAnimals = new ArrayList()
            {
                new Animal
                {
                    Name = "Heidi",
                    Height = .8,
                    Weight = 18
                },
                new Animal
                {
                    Name = "Shrek",
                    Height = 4,
                    Weight = 130
                },
                new Animal
                {
                    Name = "Congo",
                    Height = 3.8,
                    Weight = 90
                }
            };

            // You have to convert the ArrayList into an IEnumerable.
            var famAnimalEnum = famAnimals.OfType<Animal>();

            var smallAnimals = from animal in famAnimalEnum
                               where animal.Weight <= 90
                               orderby animal.Name
                               select animal;

            foreach (var animal in smallAnimals)
            {
                Console.WriteLine("{0} weighs {1}lbs",
                    animal.Name, animal.Weight);
            }

            Console.WriteLine();
        }

        static void QueryCollection()
        {
            var animalList = new List<Animal>
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77
                },
                new Animal
                {
                    Name = "Chihuahua",
                    Height = 7,
                    Weight = 4.4
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight = 200
                }
            };

            var bigDogs = from dog in animalList
                          where (dog.Weight > 70) && (dog.Height > 25)
                          orderby dog.Name
                          select dog;

            foreach (var dog in bigDogs)
            {
                Console.WriteLine("A {0} weighs {1}lbs",
                    dog.Name, dog.Weight);
            }
            Console.WriteLine();
        }

        static void QueryAnimalData()
        {
            Animal[] animals = new[]
            {
                new Animal
                {
                    Name = "German Shepherd",
                    Height = 25,
                    Weight = 77,
                    AnimalID = 1
                },
                new Animal
                {
                    Name = "Chihuahua",
                    Height = 7,
                    Weight = 4.4,
                    AnimalID = 2
                },
                new Animal
                {
                    Name = "Saint Bernard",
                    Height = 30,
                    Weight = 200,
                    AnimalID = 3
                },
                new Animal
                {
                    Name = "Pug",
                    Height = 12,
                    Weight = 16,
                    AnimalID = 1
                },
                new Animal
                {
                    Name = "Beagle",
                    Height = 15,
                    Weight = 23,
                    AnimalID = 2
                }
            };

            Owner[] owners = new[]
            {
                new Owner
                {
                    Name = "Doug Parsk",
                    OwnerID = 1
                },
                new Owner
                {
                    Name = "Sally Smith",
                    OwnerID = 2
                },
                new Owner
                {
                    Name = "Paul Brooks",
                    OwnerID = 3
                }
            };

            // Remove name and height
            var nameHeight = from a in animals
                             select new
                             {
                                 a.Name,
                                 a.Height
                             };

            // Convert to an object array
            Array arrNameHeight = nameHeight.ToArray();

            foreach (var i in arrNameHeight)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();

            // Create a group inner join.
            // Get all animals and put them in a newly created owner group
            // if their IDs match the owners ID.
            var groupJoin = from owner in owners
                            orderby owner.OwnerID
                            join animal in animals on owner.OwnerID
                            equals animal.AnimalID into ownerGroup
                            select new
                            {
                                Owner = owner.Name,
                                Animals = from owner2 in ownerGroup
                                          orderby owner2.Name
                                          select owner2
                            };

            int totalAnimals = 0;

            foreach (var ownerGroup in groupJoin)
            {
                Console.WriteLine(ownerGroup.Owner);
                
                foreach (var animal in ownerGroup.Animals)
                {
                    totalAnimals++;
                    Console.WriteLine("* {0}", animal.Name);
                }
            }
        }
    }
}
