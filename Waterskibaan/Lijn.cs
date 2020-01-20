using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Lijn
    {
        public int PositieOpDeLijn { get; set; }

        public Sporter Sporter { get; set; }

        public Lijn()
        {
            this.PositieOpDeLijn = 0;
        }

        /// <summary>
        /// Test Constructor
        /// </summary>
        /// <param name="positie"></param>
        public Lijn(int positie)
        {
            this.PositieOpDeLijn = positie;
        }
    }
}
