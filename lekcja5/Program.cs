using System;

namespace lekcja5
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Bicycle bike = new Bicycle();
            // jedziemy
            car.Ride();
            bike.Ride();
            

            // osoba
            Osoba lucjan = new Osoba();
            IGitarzysta lutek = new Osoba();
            ISkrzypek lute2 = new Osoba();
            lucjan.Graj();
            // teraz Graj() wywoływane jest jako IGitarzysta.Graj()
            lutek.Graj();
            // teraz Graj() wywoływane jest jako ISkrzypek.Graj()
            lute2.Graj();


            // klonowanie
            klonowanie.CloneTest.Run();
            

            // zwierzaki
            zwierzaki.ZwierzakiTest.Run();
            Console.ReadKey();
        }
    }
}
