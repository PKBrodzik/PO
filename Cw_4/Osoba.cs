using System;

namespace Cw_4
{
    class Osoba
    {
        public string imie;
        public string nazwisko;
        public int rokUrodzenia;

        public Osoba(string imie, string nazwisko, int rokUrodzenia)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.rokUrodzenia = rokUrodzenia;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Osoba \n {0} {1}, urodzona w {2} roku",
                this.imie, this.nazwisko, this.rokUrodzenia);
        }
    }
}
