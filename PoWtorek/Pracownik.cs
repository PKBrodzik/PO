namespace PoWtorek
{
    public class Pracownik
    {
        private string pesel;
        public string imie;
        public string nazwisko;
        private double zarobki;
        public double Zarobki
        {
            get { return zarobki; }
            set { zarobki = value; }
        }

        public Pracownik(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}

