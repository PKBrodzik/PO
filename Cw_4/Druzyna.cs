using System.Collections.Generic;

namespace lekcja4
{
    class Druzyna
    {
        private List<Bohater> druzyna;

        public Druzyna(List<Bohater> _druzyna)
        {
            this.druzyna = _druzyna;
        }

        public void DodajDoDruzyny(Bohater _boh)
        {
            this.druzyna.Add(_boh);
        }

        public void UsunZDruzyny(Bohater _boh)
        {
            this.druzyna.Remove(_boh);
        }

        public void WypiszDruzyne(bool tylkoHp = false)
        {
            foreach(Bohater boh in this.druzyna)
            {
                if (!tylkoHp)
                {
                    boh.PrzedstawSie();
                }
                boh.WypiszHp();
            }
            
        }

        private void UpdateDruzyna()
        {
            //usuwa z drużyny wszystkich "martwych" bohaterów
            druzyna.RemoveAll(item => item.CzyZyje == false);
        }

        public void ZadajCios(Bohater cel, int obrazenia)
        {
            Bohater boh = this.druzyna[this.druzyna.IndexOf(cel)];
            boh.PrzyjmijCios(obrazenia);
            UpdateDruzyna();
            boh.WypiszHp();
        }
    }
}
