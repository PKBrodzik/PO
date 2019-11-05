using System;

namespace lekcja4
{
    class Osoba
    {
        public string imie;
        public string nazwisko;
        public int rokUrodzenia;

        public Osoba()
        {

        }

        // statyczna metoda zwracajaca domyślny obiekt Osoba
        public static Osoba Create()
        {
            return new Osoba("Jan", "Kowalski", 2000);
        }

        // ta metoda może być przeciążona i przyjmować równiez parametry
        public static Osoba Create(string _imie, string _nazwisko, int _rokUrodzenia)
        {
            return new Osoba(_imie, _nazwisko, _rokUrodzenia);
        }

        public Osoba(string imie, string nazwisko, int rokUrodzenia)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.rokUrodzenia = rokUrodzenia;
        }

        // w rzeczywistych przypadkach powinniśmy unikać wypisywania na konsolę
        // raczej będziemy zwracać string, który można później wyświetlić lub nie
        public void WypiszInfo()
        {
            Console.WriteLine("Osoba \n {0} {1}, urodzona w {2} roku",
                this.imie, this.nazwisko, this.rokUrodzenia);
        }

        public int ObliczWiek()
        {
            return System.DateTime.Now.Year - this.rokUrodzenia;
        }

        // można też przeciążyć metodę ToString w kiedy wywołamy
        // Console.WriteLine(obiekt typu Osoba) zostanie ona wywołana
        public override string ToString()
        {
            return String.Format("Osoba \n {0} {1}, urodzona w {2} roku",
                this.imie, this.nazwisko, this.rokUrodzenia);
        }

    }
}
