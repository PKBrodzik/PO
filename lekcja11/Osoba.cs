using System;

namespace lekcja11
{
    public class Osoba
    {
        public Osoba(string imie, string nazwisko, DateTime dataUrodzenia)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
        }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
    }
}
