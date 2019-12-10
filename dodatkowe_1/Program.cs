using System;

namespace dodatkowe_1
{
    class Samolot
    {
        // docelowo to pole ma być tylko do odczytu, więc jest prywatne
        // a odczyt będzie odbywał się za pomocą własności (property)
        private string identyfikator; 
        public string _nazwa { get; private set ; }

        public Samolot(string _identyfikator)
        {
            this.identyfikator = _identyfikator; // możemy ustawić jego wartość w trakcie inicjalizacji obiektu
            //this.Identyfikator = "jhdjf"; to nie jest możliwe, własność tylko do odczytu nie może być zmodyfikowana
        }

        public string Identyfikator
        {
            // pobieranie pola, brak opcji set dla własności
            get { return this.identyfikator; }
        }

        public string Nazwa
        {
            get { return _nazwa; }

            // ale wciąż można to zmienić np. przez błędny kod
            set
            {
                identyfikator = value;
            }
        }
    }

    class Auto
    {
        // docelowo to pole ma być tylko do odczytu, więc jest prywatne
        // a odczyt będzie odbywał się za pomocą własności (property)
        private readonly string identyfikator;
        private string nazwa;

        public Auto(string _identyfikator)
        {
            // możemy ustawić jego wartość w trakcie inicjalizacji obiektu
            // wartość pola readonly może być ustawiona tylko przez konstruktor
            this.identyfikator = _identyfikator; 
        }

        public string Identyfikator
        {
            // pobieranie pola, brak opcji set dla własności
            get { return this.identyfikator; }
        }

        public string Nazwa
        {
            get { return nazwa; }

            set
            {
                //_identyfikator = value; teraz już nie można przypisać nowej wartości temu polu
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // przypadek 1
            Samolot boing = new Samolot("AS65746");
            //boing.Identyfikator = "AS9999"; tylko do odczytu
            boing.Nazwa = "AS9999";
            Console.WriteLine(boing.Nazwa);
            Console.ReadKey();
        }
    }
}
