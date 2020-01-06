namespace lekcja12.z_dekoratorem
{
    public class Kawa : Napoj
    {
        public override double Koszt()
        {
            return 2.00;
        }

        public override string GetOpis()
        {
            return "Czarna kawa";
        }
    }
}