using System;

namespace PoWtorek
{
    public class Car
    {
        public static int iloscKol;
        string marka;
        double pojemnosc;

        static Car()
        {
            iloscKol = 4;
        }

        public Car(string marka, double pojemnosc)
        {
            this.marka = marka;
            this.pojemnosc = pojemnosc;
        }

        public static Car Create(string marka, double pojemnosc)
        {
            return new Car(marka, pojemnosc);
        }


        ~Car()
        {
            Console.WriteLine("Zwalniam pamięć");
            Console.ReadKey();
        }
    }
}

