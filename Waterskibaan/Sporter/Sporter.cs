using System;
using System.Collections.Generic;
using System.Drawing;
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
        
        public Color KledingKleur { get; set; }

        public int BehaaldePunten { get; set; }

        public List<IMoves> Moves { get; set; }

        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves)
        {
            this.Moves = moves;
            Random rand = new Random();
            KledingKleur = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }
    }
}
