using System;

namespace CSharpTut10
{
    class Vehicle : IDrivable
    {
        // Vehicle properties
        public string Brand { get; set; }

        public Vehicle(string brand = "No Brand", int wheels = 0, double speed = 0)
        {
            this.Brand = brand;
            this.Wheels = wheels;
            this.Speed = speed;
        }

        // Properties and methods from the interface
        public double Speed { get; set; }

        public int Wheels { get; set; }

        public void Move()
        {
            Console.WriteLine($"The {this.Brand} Moves Forward at {this.Speed} MPH");
        }

        public void Stop()
        {
            Console.WriteLine($"The {this.Brand} Stops");
            this.Speed = 0;
        }
    }
}
