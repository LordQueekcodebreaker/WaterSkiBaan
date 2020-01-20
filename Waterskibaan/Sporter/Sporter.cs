using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Sporter
    {
        public int AantalRondesTeGaan { get; set; } = 0;

        public Zwemvest Zwemvest { get; set; }

        public Skies Skies { get; set; }
        //TODO :Add color
        //public Color KledingKleur { get; set; }

        public int BehaaldePunten { get; set; }

        public List<IMoves> Moves { get; set; }

        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves)
        {
            this.Moves = moves;

            //TODO :Add color

            //Random rand = new Random();

            //KledingKleur = Color.FromRgb((byte)(rand.Next(0, 256)), (byte)(rand.Next(0, 256)), (byte)(rand.Next(0, 256)));

        }
    }
}
