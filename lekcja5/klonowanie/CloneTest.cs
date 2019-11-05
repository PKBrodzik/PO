using System;

namespace lekcja5.klonowanie
{
    class CloneTest
    {
        public static void Run()
        {
            Test test1 = new Test();
            Test test2 = new Test();
            Test test3 = new Test();

            test1.liczba = 255;
            test1.poleTestowe.slowo = "słowo";
            test2 = test1;
            test3 = (Test)test1.Clone();
            // odkomentować dla punktu 17
            // test3 = test1.GlebokaKopia();
            test1.liczba = 347;
            test1.poleTestowe.slowo = "kaczka";

            Console.WriteLine(test1.liczba);
            Console.WriteLine(test2.liczba);
            Console.WriteLine(test3.liczba);
            
            Console.WriteLine(test1.poleTestowe.slowo);
            Console.WriteLine(test2.poleTestowe.slowo);
            Console.WriteLine(test3.poleTestowe.slowo);
        }
    }

    class Test2
    {
        public string slowo;
    }
}
