using System.Collections.Generic;

namespace lekcja2
{
    class Koszyk
    {
        // lista generyczna, która przechowuje tylko obiekty typu Produkt
        List<Produkt> produkty;

        public Koszyk()
        {
            // inicjalizacja pustej listy
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
