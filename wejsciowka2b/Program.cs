using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wejsciowka2b
{
    class Program
    {
        static void Main(string[] args)
        {
            Automat automat = new Automat("Tshibo Coffee Machine", "Supreme 2000");
            Napoj kawaczarna = new KawaCzarna("czarna kawa", 8.00);
            automat.PrzygotujNapoj(kawaczarna);
            Console.ReadKey();
        }
    }

    abstract class Napoj
    {
        private string nazwa;
        private double cena;

        protected Napoj(string nazwa, double cena)
        {
            this.nazwa = nazwa;
            this.cena = cena;
        }

        public double GetCena()
        {
            return this.cena;
        }

        public void Przygotuj()
        {
            Console.WriteLine($"Przygotowuję napój {nazwa}. Cena: {cena}");
        }

    }

    class KawaCzarna : Napoj
    {
        public KawaCzarna(string nazwa, double cena) : base(nazwa, cena)
        {
        }
    }

    class KawaZMlekiem : Napoj
    {
        public KawaZMlekiem(string nazwa, double cena) : base(nazwa, cena)
        {
        }
    }

    class Automat
    {
        string nazwa, model;
        private double stanKasy;

        public Automat(string nazwa, string model)
        {
            this.nazwa = nazwa;
            this.model = model;
        }

        public void PrzygotujNapoj(Napoj napoj)
        {
            this.stanKasy += napoj.GetCena();
            napoj.Przygotuj();
        }
    }
}
