using System.Collections;
using System.Collections.Generic;

namespace CSharpTut14
{
    // IEnumerable provides for iteration over a collection
    class AnimalFarm : IEnumerable
    {
        // Holds list of Animals
        private List<Animal> animalList = new List<Animal>();

        public AnimalFarm(List<Animal> animalList)
        {
            this.animalList = animalList;
        }

        public AnimalFarm()
        {
        }

        // Indexer for AnimalFarm created with this[]
        public Animal this[int index]
        {
            get { return (Animal)animalList[index]; }
            set { this.animalList.Insert(index, value); }
        }

        // Returns the number of values in the collection
        public int Count
        {
            get { return this.animalList.Count; }
        }

        // Returns an enumerator that is used to iterate through the collection
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.animalList.GetEnumerator();
        }
    }
}
