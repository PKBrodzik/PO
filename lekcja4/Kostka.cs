using System;

namespace lekcja4
{
    static class Kostka
    {
        // generator liczb losowych, powinna być tylko jedna instancja takiego obiektu
        // gdyż w przypadku utworzenia instancji za każdym losowaniem, przy niewielkich
        // odstępach czasowych możliwe jest losowanie tej samej wartości
        private static Random rnd = new Random(); 

        public static int Rzuc(int k, int ileRazy)
        {
            int wynik = 0;
            for(int i=0; i<ileRazy; i++)
            {
                wynik += rnd.Next(1, k + 1); //podobnie jak w Pythonie range (stop-step) więc dajemy +1
            }
            return wynik;
        }
    }
}