using System;
using System.Collections.Generic;

namespace wejsciowka3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Queue<Pojazd> kolejka = new Queue<Pojazd>();
            //Pojazd audi = new Samochod("Audi A6");
            //Pojazd bmw = new Samochod("BMW X6");
            //Pojazd fiat = new Samochod("Fiat 126p");
            //Pojazd romet = new Rower("Romet");
            //Pojazd kross1 = new Rower("Kross Level B4");
            //Pojazd kross2 = new Rower("Kross Level B1");

            //kolejka.Enqueue(audi);
            //kolejka.Enqueue(bmw);
            //kolejka.Enqueue(romet);
            //kolejka.Enqueue(kross1);
            //kolejka.Enqueue(kross2);
            //kolejka.Enqueue(fiat);

            //while (kolejka.Count > 0)
            //{
            //    var poj = kolejka.Dequeue();
            //    if (poj is ISkladany poj2)
            //    {
            //        poj2.Rozloz();
            //    }
            //    Console.WriteLine(poj.Jedz());
            //}

            //foreach(Pojazd poj in kolejka){
            //    if(poj is ISkladany)
            //    {
            //        ISkladany poj2 = (ISkladany)poj;
            //        poj2.Rozloz();
            //    }
            //    poj.Jedz();

            //Test ok = new Test();
            //ok.costam();

            // wejsciowka 3_B
            // organizujemy przyjęcie

            // tworzymy pracowników, klientów
            Pracownik Agata = new Pracownik("Agata", 2000, Stanowisko.Sekretarka);
            Pracownik Marek = new Pracownik("Marek", 1975, Stanowisko.Dyrektor);
            Pracownik Zbysio = new Pracownik("Zbigniew", 1965, Stanowisko.Magazynier);
            Pracownik Wojtek = new Pracownik("Wojtek", 1985, Stanowisko.Sprzedawca);

            Klient Oskar = new Klient("Oskar", 1978, 1);
            Klient Wiola = new Klient("Wioletta", 1983, 2);
            Klient Karol = new Klient("Karol", 1990, 3);

            // dodajemy osoby do kolejki oczekujących na wejście
            Queue<Osoba> oczekujacy = new Queue<Osoba>();
            oczekujacy.Enqueue(Agata);
            oczekujacy.Enqueue(Karol);
            oczekujacy.Enqueue(Wojtek);
            oczekujacy.Enqueue(Marek);
            oczekujacy.Enqueue(Oskar);
            oczekujacy.Enqueue(Wiola);
            oczekujacy.Enqueue(Zbysio);

            List<Osoba> klienci = new List<Osoba>();
            List<Osoba> pracownicy = new List<Osoba>();

            while(oczekujacy.Count > 0)
            {
                Osoba gosc = oczekujacy.Dequeue();
                if(gosc is Pracownik pgosc)
                {
                    pracownicy.Add(gosc);
                    Console.WriteLine($"Do listy gości dołączył {pgosc.Stanowisko} {pgosc.imie}");
                }
                else if(gosc is Klient)
                {
                    klienci.Add(gosc);
                    IKlient iklient = (IKlient)gosc;
                    Console.WriteLine($"Do listy gości dołączył {gosc.imie} o numerze klienta {iklient.NumerKlienta}");
                }
            }
            Console.ReadKey();
        }
    }

    abstract class Osoba
    {
        public string imie;
        public int rokUrodzenia;

        protected Osoba(string imie, int rokUrodzenia)
        {
            this.imie = imie;
            this.rokUrodzenia = rokUrodzenia;
        }
    }

    public enum Stanowisko { Sekretarka, Sprzedawca, Magazynier, Dyrektor };

    interface IPracownik
    {
        Stanowisko Stanowisko { get; set; }
    }

    interface IKlient
    {
        int NumerKlienta { get; set; }
    }

    class Pracownik : Osoba, IPracownik
    {
        public Pracownik(string imie, int rokUrodzenia, Stanowisko stanowisko) : base(imie, rokUrodzenia)
        {
            this.Stanowisko = stanowisko;
        }

        public Stanowisko Stanowisko { get; set; }
    }

    class Klient : Osoba, IKlient
    {
        public Klient(string imie, int rokUrodzenia, int numerKlienta) : base(imie, rokUrodzenia)
        {
            this.NumerKlienta = numerKlienta;
        }

        public int NumerKlienta { get; set; }
    }

    // nowe

    abstract class Pojazd
    {
        protected string nazwa;

        public Pojazd(string _nazwa)
        {
            this.nazwa = _nazwa;
        }

        public string Jedz()
        {
            return $"{this.GetType().Name} jedzie !";
        }
    }

    interface ISkladany
    {
        void Zloz();
        void Rozloz();
    }

    class Rower : Pojazd, ISkladany
    {
        public Rower(string _nazwa) : base(_nazwa)
        {
        }

        public void Rozloz()
        {
            Console.WriteLine($"Rozkładam {this.GetType().Name} {this.nazwa}");
        }

        public void Zloz()
        {
            Console.WriteLine($"Składam {this.GetType().Name} {this.nazwa}");
        }
    }

    class Samochod : Pojazd
    {
        public Samochod(string _nazwa) : base(_nazwa)
        {
        }
    }

    class Test
    {
        private string Identyfikator { get; }

        public void costam()
        {
            var a = null + 10;
            Console.WriteLine(a);
            Console.WriteLine(a.GetType());
            
        }
    }

}
