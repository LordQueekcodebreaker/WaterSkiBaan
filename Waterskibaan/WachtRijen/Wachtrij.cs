using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public abstract class Wachtrij
    {
        private Queue<Sporter> queu = new Queue<Sporter>();

        public abstract int MAX_LENGTE_RIJ { get; set; }

        public void SporterNeemtPlaats(Sporter sporter)
        {
            if (queu.Count >= MAX_LENGTE_RIJ) { return; }
            queu.Enqueue(sporter);
        }

        public List<Sporter> GetAlleSporters()
        {
            List<Sporter> SpList = new List<Sporter>();
            foreach (Sporter sp in queu)
            {
                SpList.Add(sp);
            }
            return SpList;
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> SpList = new List<Sporter>();
            int count = 0;

            foreach (Sporter sp in this.GetAlleSporters())
            {
                if (count >= aantal) { break; }
                SpList.Add(queu.Dequeue());
                count++;
            }
            return SpList;
        }

        public int GetAantal()
        {
            return queu.Count;
        }

        public override string ToString()
        {
            return $"De Wachtrij heeft {queu.Count} sporters in de wachtrij";
        }
    }
}
