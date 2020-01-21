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
        
        public Tuple<byte,byte,byte> KledingKleur { get; set; }

        public int BehaaldePunten { get; set; }

        public List<IMoves> Moves { get; set; }

        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves)
        {
            this.Moves = moves;
            Random rand = new Random();
            KledingKleur = new Tuple<byte, byte, byte>((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
        }
    }
}
