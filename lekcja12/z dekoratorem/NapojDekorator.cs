using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekcja12.z_dekoratorem
{
    public abstract class NapojDekorator : Napoj
    {
        protected Napoj napoj;
        public NapojDekorator(Napoj _napoj)
        {
            napoj = _napoj;
        }

        public override string GetOpis()
        {
            return napoj.GetOpis();
        }

        public override double Koszt()
        {
            return napoj.Koszt();
        }
    }
}