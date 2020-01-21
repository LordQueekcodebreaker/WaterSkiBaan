using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Koprol : IMoves
    {
        public int Move()
        {
            Random r = new Random();
            int b = r.Next(8);
            if (b <= 2) { return 5; }
            return 0;
        }

        public string Naam()
        {
            return "Koprol";
        }
    }
}
