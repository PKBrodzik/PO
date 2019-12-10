using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTest
{
    public enum Kierunek { Wschód, Południe, Zachód, Północ }
    class Program
    {
        static void Main(string[] args)
        {
            
            //LinkedList<int> kierunek = new LinkedList<int>(Enumerable.Range(0,3));

            //LinkedList<Kierunek> kierunek = new LinkedList<Kierunek>(Enum.GetValues(typeof(Kierunek)).Cast<Kierunek>().ToList());
            //LinkedList<Kierunek> kierunek = new LinkedList<Kierunek>((Kierunek[])Enum.GetValues(typeof(Kierunek)));

            LinkedList<Kierunek> kierunek = new LinkedList<Kierunek>();
            kierunek.AddLast(Kierunek.Wschód);
            kierunek.AddLast(Kierunek.Południe);
            kierunek.AddLast(Kierunek.Zachód);
            kierunek.AddLast(Kierunek.Północ);

            Console.WriteLine(kierunek.Last.Value);
            Console.WriteLine(kierunek.First.Value);
            Console.WriteLine(kierunek.Last.Next.Value);
            Console.ReadKey();
        }
    }

    class KierunekSwiata
    {
        public Kierunek Current { get; private set; }

        public KierunekSwiata(Kierunek current)
        {
            this.Current = current;
        }

        public void WLewo(int krok)
        {

        }

        public void WPrawo(int krok)
        {

        }
    }

    class CircleLinkedList<T>
    {
        public T First { get; private set; }
        public T Last { get; private set; }
        public T Current { get; private set; }


        public CircleLinkedList(IEnumerable<T> collection)
        {
            this.Current = collection.First<T>();
            this.First = collection.First<T>();
            this.Last = collection.Last<T>();
        }
    }
}
