using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut8
{
    class Warrior
    {
        // Define the Warrior properties
        public string Name { get; set; } = "Warrior";
        public double Health { get; set; } = 0;
        public double AttkMax { get; set; } = 0;
        public double BlockMax { get; set; } = 0;

        // Always create a single Random instance and reuse it
        // or you will get the same value over and over
        Random rnd = new Random();

        // Constructor initializes the warrior
        public Warrior(string name = "Warrior", double health = 0, double attkMax = 0, double blockMax = 0)
        {
            this.Name = name;
            this.Health = health;
            this.AttkMax = attkMax;
            this.BlockMax = blockMax;
        }

        // Generate a random attack value from 1 to the warriors maximum attack value
        public double Attack()
        {
            return this.rnd.Next(1, (int)this.AttkMax);
        }

        // Generate a random block value from 1 to the warriors maximum block value
        public double Block()
        {
            return this.rnd.Next(1, (int)this.BlockMax);
        }
    }
}
