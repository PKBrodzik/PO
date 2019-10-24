using System;

namespace Cw_4
{
    public enum Profesja { Wojownik, Złodziej, Palladyn };
    public enum Rasa { Człowiek, Elf, Niziołek, Krasnolud };

    public abstract class Bohater
    {
        protected Profesja profesja;
        protected Rasa rasa;
        protected string imie;

        protected Bohater(string imie, Rasa rasa)
        {
            this.imie = imie;
            this.rasa = rasa;
        }

        public abstract string PrzedstawSie();
    }

    class Wojownik : Bohater
    {

        public Wojownik(string imie, Rasa rasa) : base(imie, rasa)
        {
            this.profesja = Profesja.Wojownik;
        }

        public override string PrzedstawSie()
        {
                return String.Format("Nazywam się {0}.\nMoja rasa to {1} a profesja to {2}.\nDobrze macham mieczem!!!",
                    this.imie, this.rasa, this.profesja);
        }
    }

    class Zlodziej : Bohater
    {

        public Zlodziej(string imie, Rasa rasa) : base(imie, rasa)
        {
            this.profesja = Profesja.Złodziej;
        }

        public override string PrzedstawSie()
        {
            return String.Format("Nazywam się {0}.\nMoja rasa to {1} a profesja to {2}. \nSkradam się jak nikt inny!",
                this.imie, this.rasa, this.profesja);
        }
    }
}