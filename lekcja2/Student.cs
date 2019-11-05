using System;

namespace lekcja2
{
    class Student
    {
        string imie;
        string nazwisko;
        string indeks;

        public Student(string imie, string nazwisko, string indeks)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.indeks = indeks;
        }

        public void SetImie(string _imie)
        {
            // (Single Entry Point) można wykonać np. walidację
            this.imie = _imie;
        }

        public static void PowiedzCos(string _imie)
        {
            Console.WriteLine("Nazywam się {0}", _imie);
        }

        public static void PowiedzCos(int indeks, int numer)
        {
            Console.WriteLine("Nazywam się {0}", indeks);
        }

        //źle, te same typy argumentów
        //public static void PowiedzCos(int numer, int indeks)
        //{
        //    Console.WriteLine("Nazywam się {0}", indeks);
        //}
    }
}
