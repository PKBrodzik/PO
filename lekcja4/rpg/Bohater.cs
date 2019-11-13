using System;
using System.Collections.Generic;

namespace lekcja4
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
        public Ekwipunek ekwipunek; // kontener obiektów typu Przedmiot
        public Bron GlownaBron;
        protected string imie;
        protected double zywotnosc = 1.0;
        protected int hp; // Hit Points - aktualne punkty życia
        protected int maxHp; // maksymalne punkty życia do jakich może uleczyć się postać, może być zmienione w trakcie gry
        protected int pancerz = 0; //może być zmodyfikowany przez założenie jakiegoś przedmiotu lub magicznie
        protected int pt; // punkty taktyki

        protected Bohater(string _imie, Rasa _rasa, int _hp)
        {
            this.imie = _imie;
            this.rasa = _rasa;
            this.ekwipunek = new Ekwipunek();
            this.hp = _hp;
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

        abstract public void ZadajCios(Bohater wrog);
        public void ustawGlownaBron(Bron b)
        {
            this.GlownaBron = b;
        }
        
        public abstract int MocAtaku();
        public void WypiszHp()
        {
            // żywotność sformatowana jako wartość procentowa, sprawdź inne możliwości w dokumentacji
            if (CzyZyje)
            {
                Console.WriteLine($"{imie}: {hp}/{maxHp} HP Ż: {zywotnosc:p}");
            }
            else
            {
                Console.WriteLine($"{imie} jest martwy...");
            }
        }
    }

    class Wojownik : Bohater
    {
        private int sila;

        public Wojownik(string imie, Rasa rasa, int hp) : base(imie, rasa, hp)
        {
            this.profesja = Profesja.Wojownik;
            this.maxHp = hp;
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

        public override void ZadajCios(Bohater wrog)
        {
            wrog.PrzyjmijCios(GlownaBron.GetObrazenia() + MocAtaku());
        }
    }

    class Zlodziej : Bohater
    {
        private int zrecznosc;

        public Zlodziej(string imie, Rasa rasa, int hp) : base(imie, rasa, hp)
        {
            this.profesja = Profesja.Złodziej;
            this.maxHp = hp;
            this.zrecznosc = 18;
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

        public override void ZadajCios(Bohater wrog)
        {
            throw new NotImplementedException();
        }
    }

    class Lucznik : Bohater
    {
        private int zrecznosc;

        public Lucznik(string imie, Rasa rasa, int hp) : base(imie, rasa, hp)
        {
            this.profesja = Profesja.Łucznik;
            this.maxHp = 50;
            this.zrecznosc = 15;
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

        public override void ZadajCios(Bohater wrog)
        {
            throw new NotImplementedException();
        }
    }

    public class Ekwipunek
    {
        List<Przedmiot> listaPrzedmiotow;

        public Ekwipunek()
        {
            this.listaPrzedmiotow = new List<Przedmiot>();
        }

        public void DodajPrzedmiot(Przedmiot _p)
        {
            // tutaj należy wprowadzić jakąć metodę sprawdzania czy można jeszcze dodać ekwipunek np. max udźwig.
            this.listaPrzedmiotow.Add(_p);
        }

        public void UsunPrzedmiot(Przedmiot _p)
        {
            this.listaPrzedmiotow.Remove(_p);
        }

        public void WyswietlEkwipunek()
        {
            foreach(Przedmiot p in this.listaPrzedmiotow)
            {

            }
        }
    }

    abstract public class Przedmiot
    {
        public string nazwa;
        public double waga, wytrzymalosc;

        protected Przedmiot(string nazwa, double waga, double wytrzymalosc)
        {
            this.nazwa = nazwa;
            this.waga = waga;
            this.wytrzymalosc = wytrzymalosc;
        }
    }

    public enum RodzajBroni { MieczJednoręczny, MieczDwuręczny, Łuk, Kostur, Kusza, Sztylet }

    public class Bron : Przedmiot
    {
        ObrazeniaBroni obrazeniaBroni;
        RodzajBroni rodzaj;

        public Bron(string nazwa, double waga, double wytrzymalosc, ObrazeniaBroni obrBroni, RodzajBroni _rodzaj) : base(nazwa, waga, wytrzymalosc)
        {
            this.obrazeniaBroni = obrBroni;
            this.rodzaj = _rodzaj;
        }

        public override string ToString()
        {
            return String.Format($"{this.rodzaj} {this.nazwa}, waga: {waga}, wytrzymałość: {wytrzymalosc}");
        }

        public int GetObrazenia()
        {
            return this.obrazeniaBroni.GenerujPunktyObrazen();
        }
    }

    public class ObrazeniaBroni
    {
        // w Dungeons and Dragons obrażenia broni białej mogą mieć wartość np. 2k4 + 2
        // da się oczywiście to zaimplementować prościej, okreslając warunki generowania kolejnej wartości
        // losowej poprzez określenie przedziału, ale biorąc pod uwagę rozkład prawdopodobieństwa sumy oczek dla 
        // więcej niż jednej kostki okazuje się, że przy uproszczonym podejściu pomijamy ten czynnik
        // np. dla 2k4 sumę oczek równą 2 możemy osiągnąć na 2 sposoby, 1+1 i 1+1 (biorąc pod uwagę kolejność kostek),
        // suma 3 to 1+2 lub 2+1, suma 4 to 1+3, 3+1, 2+2, 2+2 itd. biorąc pod uwagę kolejność kostek 
        int kostka, ileKostek, modyfikator;

        public ObrazeniaBroni(int kostka, int ileKostek, int modyfikator)
        {
            this.kostka = kostka;
            this.ileKostek = ileKostek;
            this.modyfikator = modyfikator;
        }

        public int GenerujPunktyObrazen()
        {
            return Kostka.Rzuc(kostka, ileKostek) + modyfikator;
        }
    }
}