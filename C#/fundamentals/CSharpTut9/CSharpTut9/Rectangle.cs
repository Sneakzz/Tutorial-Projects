using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut9
{
    class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Name = "Rectangle";
            this.Length = length;
            this.Width = width;
        }

        public override double Area()
        {
            return this.Length * this.Width;
        }

        // You can replace the method using override
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"It has a Length of {this.Length} and Width of {this.Width}");
        }
    }
}
