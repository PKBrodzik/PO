using System;

namespace lekcja5
{
    class Osoba : IGitarzysta, ISkrzypek
    {
        public void Graj()
        {
            Console.WriteLine("Gram, ale nie wiem na czym");
        }
        void IGitarzysta.Graj()
        {
            Console.WriteLine("Gram na gitarze");
        }
        void ISkrzypek.Graj()
        {
            Console.WriteLine("Gram na skrzypcach");
        }
    }
}
