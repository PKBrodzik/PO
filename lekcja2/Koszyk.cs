using System.Collections.Generic;

namespace lekcja2
{
    class Koszyk
    {
        List<Produkt> produkty;

        public Koszyk()
        {
            this.produkty = new List<Produkt>();
        }

        public void DodajProdukt(Produkt p)
        {
            this.produkty.Add(p);
        }

        public void WyswietlProdukty()
        {
            foreach(Produkt p in this.produkty)
            {
                p.WypiszInfo();
            }
        }

    }
}
