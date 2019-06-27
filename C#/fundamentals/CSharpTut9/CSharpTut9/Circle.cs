using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut9
{
    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Name = "Circle";
            this.Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * (Math.Pow(this.Radius, 2.0));
        }

        // You can replace the method using override
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"It has a Radius of {this.Radius}");
        }
    }
}
