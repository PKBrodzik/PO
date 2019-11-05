using System;

namespace lekcja2
{
    class Produkt
    {
        string nazwa;
        float cena;

        public Produkt(string _nazwa, float _cena)
        {
            this.nazwa = _nazwa;
            this.cena = _cena;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Produkt: {0} - cena: {1}", this.nazwa, this.cena);
        }
    }
}
