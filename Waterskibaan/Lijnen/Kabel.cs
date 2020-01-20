using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Kabel
    {
        public LinkedList<Lijn> Lijnen = new LinkedList<Lijn>();
        public bool IsStartPositieLeeg()
        {
            return Lijnen.First == null || Lijnen.First.Value.PositieOpDeLijn != 0;

        }
        public void ToevoegenAanLijst(Lijn lijn)
        {
            Lijnen.AddLast(lijn);
        }

        /// <summary>
        /// Methode voegt een lijn toe aan de eerste positie
        /// </summary>
        /// <param name="lijn"></param>
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                Lijnen.AddFirst(lijn);
                lijn.PositieOpDeLijn = 0;
            }
        }

        public void VerschuifLijnen()
        {
            var laatsteLijnTerugNaarStart = false;
            foreach (var lijn in Lijnen)
            {
                lijn.PositieOpDeLijn++;

                if (lijn.PositieOpDeLijn == 10)
                {
                    lijn.PositieOpDeLijn = 0;
                    laatsteLijnTerugNaarStart = true;
                    //ronde eraf
                    lijn.Sporter.AantalRondesTeGaan--;
                }
            }
            //terug naar af omdat lijnen in volgorde van positie moeten staan
            if (laatsteLijnTerugNaarStart)
            {
                var laaststelijn = Lijnen.Last.Value;
                Lijnen.RemoveLast();
                Lijnen.AddFirst(laaststelijn);
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            var laatstelijn = Lijnen.Last;
            if (laatstelijn != null && laatstelijn.Value.PositieOpDeLijn == 9 && laatstelijn.Value.Sporter.AantalRondesTeGaan == 1)
            {
                var verwijderdelijn = Lijnen.Last.Value;
                verwijderdelijn.Sporter = null;
                Lijnen.RemoveLast();
                return verwijderdelijn;
            }
            return null;
        }


        private string printLijst()
        {
            string kabellijst = "";
            foreach (Lijn lijn in Lijnen)
            {
                kabellijst = kabellijst + lijn.PositieOpDeLijn+ "|";
            }
            if (kabellijst.Length > 0)
            {
                kabellijst = kabellijst.Remove(kabellijst.Length - 1);
            }
            return kabellijst;

        }

        public override string ToString()
        {
            return printLijst();
        }
    }
}

