using System;

namespace lekcja5
{
    class Car : Vehicle, IRideable
    {
        public void Ride()
        {
            Console.WriteLine("Bruuuummmm...");
        }
    }
}
