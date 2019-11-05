using System;
using System.Collections.Generic;

namespace Cw_4
{
    class RpgTest
    {
        public static void RunTest()
        {
            // 1. Tworzymy nowych bohaterów
            Wojownik zdzich = new Wojownik("Zdzich", Rasa.Człowiek);
            Zlodziej maniek = new Zlodziej("Maniek", Rasa.Niziołek);
            Lucznik olga = new Lucznik("Olga", Rasa.Elf);
            Wojownik bolo = new Wojownik("Bolo", Rasa.Krasnolud);

            // teraz tworzymy "drużynę"
            List<Bohater> druzynaLista = new List<Bohater>();
            druzynaLista.Add(zdzich);
            druzynaLista.Add(maniek);
            druzynaLista.Add(olga);
            druzynaLista.Add(bolo);

            // albo

            //List<Bohater> druzyna = new List<Bohater>
            //{
            //    zdzich,
            //    maniek,
            //      ...
            //};

            foreach (Bohater boh in druzynaLista)
            {
                boh.PrzedstawSie();
                Console.WriteLine("Moc ataku: {0}", boh.MocAtaku());
            }


            zdzich.PrzyjmijCios(10);
            maniek.PrzyjmijCios(5);
            olga.PrzyjmijCios(20);
            foreach (Bohater boh in druzynaLista)
            {
                boh.WypiszHp();
                Console.WriteLine(boh.MocAtaku());
            }

            /*
             * dla łatwiejszego zarządzania drużyną można napisać oddzielną klasę, która będzie ułatwiała wykonywanie
             * operacji dla całej drużyny, bez konieczności iterowania w tej głównej metodzie
             */

            Druzyna druzyna = new Druzyna(druzynaLista);
            druzyna.WypiszDruzyne();
            druzyna.WypiszDruzyne(true);

            // teraz ktoś otrzyma cios

            druzyna.ZadajCios(olga, 13);
            System.Threading.Thread.Sleep(1000);
            druzyna.ZadajCios(olga, 12);
            System.Threading.Thread.Sleep(1000);
            druzyna.ZadajCios(olga, 8);


        }
    }
}
