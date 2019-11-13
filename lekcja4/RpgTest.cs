using System;
using System.Collections.Generic;

namespace lekcja4
{
    class RpgTest
    {
        public static void RunTest()
        {
            // 1. Tworzymy nowych bohaterów
            Wojownik zdzich = new Wojownik("Zdzich", Rasa.Człowiek, 80);
            Zlodziej maniek = new Zlodziej("Maniek", Rasa.Niziołek, 60);
            Lucznik olga = new Lucznik("Olga", Rasa.Elf, 70);
            Wojownik bolo = new Wojownik("Bolo", Rasa.Krasnolud, 90);

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
            druzyna.WypiszDruzyne(true);

            // Zdzich otrzyma przedmiot
            zdzich.ustawGlownaBron(new Bron("Kosimazaki", 6.54, 80, new ObrazeniaBroni(4, 2, 2), RodzajBroni.MieczJednoręczny));
            Bohater wielkiKrasnolud = new Wojownik("Król Krasnoludów", Rasa.Krasnolud, 150);

            // sprawdzimy jak się ta broń sprawuje
            while(wielkiKrasnolud.CzyZyje)
            {
                zdzich.ZadajCios(zdzich.GlownaBron, wielkiKrasnolud);
                wielkiKrasnolud.WypiszHp();
                System.Threading.Thread.Sleep(2000);
            }
            

            
            
            

            Console.ReadKey();
        }
    }
}
