using System;

namespace lekcja12.z_dekoratorem
{
    class Czekolada : NapojDekorator
    {

        public Czekolada(Napoj _napoj):base(_napoj)
        {
        }

        // zmieniamy sposób obliczania kosztu
        public override double Koszt()
        {
            return 0.80 + napoj.Koszt();
        }

        // oraz opis
        public override string GetOpis()
        {
            return napoj.GetOpis() + ", Czekolada";
        }
    }
}