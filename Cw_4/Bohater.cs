using System;

namespace Cw_4
{
    // deklaracja enum'a może byc wykonana poza klasą
    // jeżeli chcemy mieć do niego dostęp również w innym miejscu
    // projektu (np. inicjalizując nowy obiekt)
    public enum Profesja { Wojownik, Złodziej, Palladyn, Łucznik };
    public enum Rasa { Człowiek, Elf, Niziołek, Krasnolud };

    public abstract class Bohater
    {
        protected Profesja profesja;
        protected Rasa rasa;
        protected string imie;
        protected double zywotnosc = 1.0;
        protected int hp;
        protected int maxHp;
        protected int pancerz = 0;
        protected int pt; // punkty taktyki

        protected Bohater(string _imie, Rasa _rasa)
        {
            this.imie = _imie;
            this.rasa = _rasa;
        }

        // użycie właściwości (property) - publiczny odczyt, prywatny zapis
        public bool CzyZyje { get; private set; } = true;

        public abstract void PrzedstawSie();
        public virtual void PrzyjmijCios(int obrazenia)
        {
            this.hp -= (obrazenia - this.pancerz);
            Console.WriteLine($"{this.profesja} {this.imie} otrzymał {obrazenia} punktów obrażeń");
            if (this.hp <= 0)
            {
                this.CzyZyje = false;
                this.zywotnosc = 0;
                Console.WriteLine($"{this.profesja} {this.imie} zginął!");
            }
            else
                this.zywotnosc = (double)this.hp / (double)this.maxHp;
        }
        public abstract int MocAtaku();
        public void WypiszHp()
        {
            Console.WriteLine($"{imie}: {hp}/{maxHp} HP");
        }

    }

    class Wojownik : Bohater
    {
        private int sila;

        public Wojownik(string imie, Rasa rasa) : base(imie, rasa)
        {
            this.profesja = Profesja.Wojownik;
            this.maxHp = 70;
            this.hp = maxHp;
            this.pt = 1;
            this.sila = 15;
        }

        public override int MocAtaku()
        {
            return (int)(this.sila * this.zywotnosc);
        }

        public override void PrzedstawSie()
        {
                Console.WriteLine(String.Format("Nazywam się {0}.\nMoja rasa to {1} a profesja to {2}.\nDobrze macham mieczem!!!",
                    this.imie, this.rasa, this.profesja));
        }
    }

    class Zlodziej : Bohater
    {
        private int zrecznosc;

        public Zlodziej(string imie, Rasa rasa) : base(imie, rasa)
        {
            this.profesja = Profesja.Złodziej;
            this.maxHp = 40;
            this.zrecznosc = 18;
            this.hp = maxHp;
            this.pt = 4;
        }

        public override int MocAtaku()
        {
            return (int)(this.zrecznosc * this.zywotnosc);
        }

        public override void PrzedstawSie()
        {
            Console.WriteLine(String.Format("Nazywam się {0}.\nMoja rasa to {1} a profesja to {2}. \nSkradam się jak nikt inny!",
                this.imie, this.rasa, this.profesja));
        }
    }

    class Lucznik : Bohater
    {
        private int zrecznosc;

        public Lucznik(string imie, Rasa rasa) : base(imie, rasa)
        {
            this.profesja = Profesja.Łucznik;
            this.maxHp = 50;
            this.zrecznosc = 15;
            this.hp = maxHp;
            this.pt = 3;
        }

        public override int MocAtaku()
        {
            return (int)(this.zrecznosc * this.zywotnosc);
        }

        public override void PrzedstawSie()
        {
            Console.WriteLine(String.Format("Nazywam się {0}.\nMoja rasa to {1} a profesja to {2}. \nSzyję z łuku raz za razem!",
                this.imie, this.rasa, this.profesja));
        }
    }
}