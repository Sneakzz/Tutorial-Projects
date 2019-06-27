using System;

namespace CSharpTut10
{
    // Because we implemented the ElectronicDevice interface,
    // any other device we create will know exactly how to interface with it.
    class Television : IElectronicDevice
    {
        public int Volume { get; set; }

        public void Off()
        {
            Console.WriteLine("The TV is Off");
        }

        public void On()
        {
            Console.WriteLine("The TV is On");
        }

        public void VolumeDown()
        {
            if (this.Volume != 0) this.Volume--;
            Console.WriteLine($"The TV Volume is at {this.Volume}");
        }

        public void VolumeUp()
        {
            if (this.Volume != 100) this.Volume++;
            Console.WriteLine($"The TV Volume is at {this.Volume}");
        }
    }
}
