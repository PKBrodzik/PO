using System;
using System.Collections.Generic;
using System.Linq;

namespace lekcja7
{
    class Program
    {
        static void Main(string[] args)
        {
            Platforma platforma = new Platforma(10, 10);
            Robot artoo = new Robot("R2D2", 100);
            platforma.Robot = artoo;
            artoo.RegisterObserver(platforma);
            platforma.Rysuj();
            artoo.IdzDoPrzodu(3);
            artoo.ObrocWPrawo(1);
            artoo.IdzDoPrzodu(4);
            artoo.ObrocWLewo(1);
            artoo.IdzDoPrzodu(3);
            artoo.ObrocWPrawo(3);
            artoo.IdzDoPrzodu(10);
            platforma.Rysuj();
            Console.ReadKey();
        }
    }

    class Platforma : IObserver
    {
        public Platforma(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public Robot Robot { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Rysuj()
        {
            // rysowanie planszy
            // czyścimy konsolę
            Console.Clear();
            // pierwszy wiersz
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("\u250F");
            for (int w=0; w<Width; w++)
            {
                Console.Write("\u2501\u2501\u2501");
            }
            Console.WriteLine("\u2513");

            // "środek" planszy
            for(int h=0; h<Height; h++)
            {
                Console.Write("\u2503");
                for (int w = 0; w < Width; w++)
                {
                    if(this.Robot.AktualnaPozycja.x == w & this.Robot.AktualnaPozycja.y == h)
                    {
                        Console.Write(" R ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine("\u2503");
            }

            // ostatni wiersz
            Console.Write("\u2517");
            for (int w = 0; w < Width; w++)
            {
                Console.Write("\u2501\u2501\u2501");
            }
            Console.WriteLine("\u251B");

            // dane o robocie
            Console.WriteLine($"Robot odwrócony w kierunku: {Robot.ZwroconyWKierunku}");
            Console.WriteLine($"Stan baterii: {Robot.StanBaterii()} %");
            Console.WriteLine($"Aktualna pozycja robota: {Robot.AktualnaPozycja}");

        }

        public void Update()
        {
            System.Threading.Thread.Sleep(1000);
            this.Rysuj();
        }
    }

    public enum Kierunek { Wschód, Południe, Zachód, Północ }

    // klasa do przechodzenia przez elementy kolekcji w nieskończoność zawrówno "w lewo" jak i "w prawo"
    // frozen oznacza, że przekazana kolekcja nie może być zmieniona
    class FrozenCircleRotate<T>
    {      
        private int currentIndex;
        private int elementCount;
        private IEnumerable<T> collection;

        public FrozenCircleRotate(IEnumerable<T> _collection, int start=0)
        {
            this.Current = _collection.ElementAt(start);
            this.currentIndex = 0;
            this.elementCount = _collection.Count();
            this.collection = _collection;
        }

        public T Current
        {
            get;
            private set;
        }

        public void RotateLeft(int steps)
        {
            for(int i=0; i<steps; i++)
            {
                if(this.currentIndex == 0)
                {
                    this.currentIndex = elementCount - 1;
                }
                else
                {
                    this.currentIndex--;
                }
            }
            this.Current = this.collection.ElementAt(this.currentIndex);
        }

        public void RotateRight(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (this.currentIndex == this.elementCount - 1)
                {
                    this.currentIndex = 0;
                }
                else
                {
                    this.currentIndex++;
                }
            }
            this.Current = this.collection.ElementAt(this.currentIndex);
        }
    }

    class Robot : IObservable
    {
        public string nazwa;
        public Pozycja AktualnaPozycja { get; private set; }
        public Kierunek OstatniKierunekRuchu { get; private set; }
        public Kierunek ZwroconyWKierunku { get; private set; }
        private FrozenCircleRotate<Kierunek> obracanie;
        private int bateria;
        private readonly int maksymalnaMocBaterii;
        private IObserver platforma;
        private bool wyladowany = false;

        public Robot(string nazwa, int mocBaterii) 
        {
            this.nazwa = nazwa;
            this.bateria = mocBaterii;
            this.maksymalnaMocBaterii = mocBaterii;
            this.AktualnaPozycja = new Pozycja(0, 0);
            this.ZwroconyWKierunku = Kierunek.Wschód;
            this.obracanie = new FrozenCircleRotate<Kierunek>((Kierunek[])Enum.GetValues(typeof(Kierunek)));
        }

        private void Idz(Kierunek k, int kroki)
        {
            // modyfikatory współrzędnych x i y
            int xMod = 0;
            int yMod = 0;

            if(k == Kierunek.Wschód) { xMod = 1; }
            else if(k == Kierunek.Północ) { yMod = -1; }
            else if(k == Kierunek.Południe) { yMod = 1; }
            else if(k == Kierunek.Zachód) { xMod = -1; }

            Pozycja nastepnaPozycja = new Pozycja(this.AktualnaPozycja.x, this.AktualnaPozycja.y);
            for (int i=0; i<kroki; i++)
            {
                try
                {
                    nastepnaPozycja.x += xMod;
                    nastepnaPozycja.y += yMod;
                    
                    if(this.wyladowany)
                    {
                        Console.WriteLine("Robot nigdzie się nie ruszy. Bateria wyładowana.");
                    }
                    else if (nastepnaPozycja.x < 0 | nastepnaPozycja.y < 0)
                    {
                        throw new RuchZaPlatformeException();
                    }
                    else
                    {
                        this.AktualnaPozycja.x = nastepnaPozycja.x;
                        this.AktualnaPozycja.y = nastepnaPozycja.y;
                        this.UpdateBateria();
                        this.NotifyObservers();
                    }
                }
                catch(RuchZaPlatformeException e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
        }

        public void IdzDoPrzodu(int ileKrokow)
        {
            this.Idz(this.ZwroconyWKierunku, ileKrokow);
        }

        public void IdzDoTylu(int ileKrokow)
        {
            this.Idz(this.ZwroconyWKierunku+2, ileKrokow);
        }

        public void IdzDoPunktu(Pozycja p)
        {
            throw new NotImplementedException();
        }

        public void ObrocWLewo(int times)
        {
            this.obracanie.RotateLeft(times);
            this.ZwroconyWKierunku = this.obracanie.Current;
        }

        public void ObrocWPrawo(int times)
        {
            this.obracanie.RotateRight(times);
            this.ZwroconyWKierunku = this.obracanie.Current;
        }

        public void PodajPozycje()
        {
            Console.WriteLine(this.AktualnaPozycja.ToString());
        }

        private void UpdateBateria()
        {
            try
            {
                if(this.bateria == 0)
                {
                    throw new BateriaWyladowanaException();
                }
                this.bateria -= 1;
            }
            catch (BateriaWyladowanaException e)
            {
                Console.WriteLine(e.Message);
                this.wyladowany = true;
            }
        }

        public float StanBaterii()
        {
            return (float)this.bateria/(float)this.maksymalnaMocBaterii * 100;
        }

        public void RegisterObserver(IObserver observer)
        {
            this.platforma = observer;
        }

        public void UnregisterObserver()
        {
            this.platforma = null;
        }

        public void NotifyObservers()
        {
            platforma.Update();
        }
    }

    class RuchZaPlatformeException : Exception
    {
        public RuchZaPlatformeException() : base("Robot nie może poruszać się poza platformą!")
        {
        }
    }

    class BateriaWyladowanaException : Exception
    {
        public BateriaWyladowanaException():base("Bateria jest wyładowana!")
        {
        }
    }

    class Pozycja
    {
        public int x, y;

        public Pozycja(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return String.Format($"Pozycja({x},{y})");
        }
    }

    interface IObserver
    {
        void Update();
    }

    interface IObservable
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver();
        void NotifyObservers();
    }
}