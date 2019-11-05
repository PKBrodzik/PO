using System;

namespace lekcja4
{
    class Student : Osoba
    {
        public int numerIndeksu;


        public Student(string imie, string nazwisko, int rokUrodzenia, int indeks) : base(imie, nazwisko, rokUrodzenia)
        {
            this.numerIndeksu = indeks;
        }

        public Student(Osoba osoba, int indeks) : base(osoba.imie, osoba.nazwisko, osoba.rokUrodzenia)
        {
            this.numerIndeksu = indeks;
        }

        //public Student(Osoba osoba, int indeks)
        //{
        //    this.imie = osoba.imie;
        //    this.nazwisko = osoba.nazwisko;
        //    this.rokUrodzenia = osoba.rokUrodzenia;
        //    this.numerIndeksu = indeks;
        //}

        public new void WypiszInfo()
        {
            //base.WypiszInfo();
            Console.WriteLine("\n numer indeksu: {0}", this.numerIndeksu);
        }

       public new string ToString()
        {
            return "To jest Student";
        }
    }
}
