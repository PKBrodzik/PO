using System;

namespace lekcja5
{
    class Bicycle : Vehicle, IRideable
    {
        public void Ride()
        {
            Console.WriteLine("Pyrku... pyrku....");
        }

    }
}
