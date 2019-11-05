using System;

namespace lekcja5.klonowanie
{
    class Test : ICloneable
    {
        public int liczba;
        public Test2 poleTestowe;

        public Test()
        {
            this.poleTestowe = new Test2();
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public Test GlebokaKopia()
        {
            Test tempTest = new Test();
            tempTest.liczba = this.liczba;
            tempTest.poleTestowe.slowo = this.poleTestowe.slowo;
            return tempTest;
        }

    }

}
