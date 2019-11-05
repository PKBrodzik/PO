namespace lekcja3
{
    public class Pracownik
    {
        private string pesel;
        public string imie;
        public string nazwisko;
        private double zarobki;
        // pole typu właściwość (property) połączona z prywatnym polem klasy
        public double Zarobki
        {
            get { return zarobki; } // zwraca wartość pola zarobki
            set { //pozwala ustawić wartość pola zarobki i wykonać np. jakiś preprocessing lub walidację
                if (value < 0)
                    zarobki = 0;
                else
                    zarobki = value;
                } 
        }

        public Pracownik(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}

