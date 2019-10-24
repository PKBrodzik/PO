using System;

namespace PoWtorek
{
    class Program
    {
        static void Main(string[] args)
        {
            Car autko = new Car("Ford", 1997);
            Car autko2 = Car.Create("Ford", 1997);
            Console.WriteLine(Car.iloscKol);
            Console.ReadKey();

            //pracownik

            Pracownik konrad = new Pracownik("Konrad", "Jakiśtam");
            konrad.Zarobki = 2500.00;
            Console.WriteLine("Pracownik: {0} {1}", konrad.imie, konrad.nazwisko);

            Type type = konrad.GetType();

            foreach (var f in type.GetFields())
            {
                Console.WriteLine(
                    String.Format("Nazwa: {0}, Typ: {2},  Wartość: {1}", f.Name, f.GetValue(konrad), f.FieldType));
            }
            Console.ReadKey();
        }
    }
}

