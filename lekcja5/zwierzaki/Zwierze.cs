using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekcja5.zwierzaki
{
    public enum Rozmiar { maleńki, mały, średni, duży, ogromny};

    public abstract class Zwierze : IZwierze
    {
        string imie;
        double waga;
        Rozmiar rozmiar;

        protected Zwierze(string _imie, double _waga, Rozmiar _rozmiar)
        {
            this.imie = _imie;
            this.waga = _waga;
            this.rozmiar = _rozmiar;
        }

        public object Copy()
        {
            return this.MemberwiseClone();
        }

        public abstract void CoJem();
        public abstract void JakSiePoruszam();
    }

    class Pies : Zwierze
    {
        public Pies(string _imie, double _waga, Rozmiar _rozmiar) : base(_imie, _waga, _rozmiar)
        {
        }

        public override void CoJem()
        {
            Console.WriteLine("Jem karmę dla psów.");
        }

        public override void JakSiePoruszam()
        {
            Console.WriteLine("Biegam na czterech łapach.");
        }
    }

    class Wilk : Zwierze
    {
        public Wilk(string _imie, double _waga, Rozmiar _rozmiar) : base(_imie, _waga, _rozmiar)
        {
        }

        public override void CoJem()
        {
            Console.WriteLine("Zjem co upoluję.");
        }

        public override void JakSiePoruszam()
        {
            Console.WriteLine("Biegam na czterech łapach");
        }
    }

    class Rekin : Zwierze
    {
        public Rekin(string _imie, double _waga, Rozmiar _rozmiar) : base(_imie, _waga, _rozmiar)
        {
        }

        public override void CoJem()
        {
            Console.WriteLine("Zjadam inne ryby... czasem człowieki.");
        }

        public override void JakSiePoruszam()
        {
            Console.WriteLine("Pływam.");
        }
    }

    class Orzel : Zwierze
    {
        public Orzel(string _imie, double _waga, Rozmiar _rozmiar) : base(_imie, _waga, _rozmiar)
        {
        }

        public override void CoJem()
        {
            Console.WriteLine("Fruwam sobie tu i tam.");
        }

        public override void JakSiePoruszam()
        {
            Console.WriteLine("Co upoluję to zjadam.");
        }
    }

    class Krokodyl : Zwierze
    {
        public Krokodyl(string _imie, double _waga, Rozmiar _rozmiar) : base(_imie, _waga, _rozmiar)
        {
        }

        public override void CoJem()
        {
            Console.WriteLine("Lubię dziabnąć jakąś antylopę.");
        }

        public override void JakSiePoruszam()
        {
                Console.WriteLine("Pływam w rzekach i bagnach. Umiem też łazić na lądzie.");
            }
    }

    class ZwierzakiTest
    {
        public static void Run()
        {
            Zwierze orzel = new Orzel("Franek", 7, Rozmiar.średni);
            Zwierze krokodyl = new Krokodyl("Kieł", 7, Rozmiar.duży);
            Zwierze wilk = new Wilk("Bajkał", 7, Rozmiar.średni);

            Console.WriteLine(orzel);
            Console.WriteLine(krokodyl);
            Console.WriteLine(wilk);

            Console.WriteLine(orzel.Copy());
        }
    }
}
