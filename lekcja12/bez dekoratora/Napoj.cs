using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekcja12.bez_dekoratora
{
    public abstract class Napoj
    {
        public string Opis { get { return this._opis; } }
        public double Koszt { get { return this._koszt; } }
        protected string _opis;
        protected double _koszt;
        protected bool mleko = false;
        protected bool cukier = false;
        // itd...
    }

    // teraz możemy dodawać konkretne klasy napojów

    class Espresso : Napoj
    {
        public Espresso()
        {
            this._opis = "Espresso w stylu włoskim!";
            this._koszt = 1.50;
        }
    }

    class KawaZMlekiem : Napoj
    {
        public KawaZMlekiem()
        {
            this._opis = "Klasyczna kawa z mlekiem";
            this.mleko = true;
            this._koszt = 2.00;
            // teraz trzeba by policzyć koszt napoju uwzględniając wszystkie dodatki
            if (this.mleko)
            {
                this._koszt += 0.50;
            }
            else if (this.cukier)
            {
                this._koszt += 0.10;
            }
        }
    }

}
