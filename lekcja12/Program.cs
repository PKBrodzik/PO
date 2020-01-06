using System;

namespace lekcja12
{
    class Program
    {
        static void Main(string[] args)
        {
            // przykład bez wzorca dekorator
            bez_dekoratora.Napoj kawa = new bez_dekoratora.KawaZMlekiem();
            Console.WriteLine(kawa.Opis + " kosztuje: " + $"{kawa.Koszt}");
            //Console.ReadKey();

            // teraz przykład z wykorzystaniem wzorca dekorator
            z_dekoratorem.Napoj nowaKawa = new z_dekoratorem.Kawa();
            Console.WriteLine(nowaKawa.GetOpis() + " kosztuje: " + $"{nowaKawa.Koszt()}");

            // dodajemy mleko
            nowaKawa = new z_dekoratorem.Mleko(nowaKawa);
            Console.WriteLine(nowaKawa.GetOpis() + " kosztuje: " + $"{nowaKawa.Koszt()}");

            // i czekoladę
            nowaKawa = new z_dekoratorem.Czekolada(nowaKawa);
            Console.WriteLine(nowaKawa.GetOpis() + " kosztuje: " + $"{nowaKawa.Koszt()}");

            Console.ReadKey();
        }
    }
}
