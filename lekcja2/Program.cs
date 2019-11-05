using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekcja2
{
    class Program
    {
        static void Main(string[] args)
        {

            Koszyk k = new Koszyk();
            k.DodajProdukt(new Produkt("mleko", 2));
            k.DodajProdukt(new Produkt("jajka", 5));

            k.WyswietlProdukty();
            Student.PowiedzCos("Marek");
            Console.ReadKey();

            Math.Pow(2, 2);
        }
    }
}
