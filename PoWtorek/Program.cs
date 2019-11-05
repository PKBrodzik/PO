using System;

namespace lekcja3
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

            // Początek przykładowego wykorzystanie mechanizmu refleksji, który pozwala na pobieranie
            // metadanych o obiektach - np. nazwa klasy, jej pola, metody, modyfikatory dostępu itd.
            Type type = konrad.GetType();
            // pobieramy listę wszystkich pól danego typu obiektu (ale tylko publiczne)
            foreach (var f in type.GetFields())
            {
                Console.WriteLine(
                    String.Format("Nazwa: {0}, Typ: {2},  Wartość: {1}", f.Name, f.GetValue(konrad), f.FieldType));
            }
            Console.ReadKey();
        }
    }
}

