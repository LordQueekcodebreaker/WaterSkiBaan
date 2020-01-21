using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Salto : IMoves
    {
        public int Move()
        {
            Random r = new Random();
            int b = r.Next(8);
            if (b <= 2) { return 2; }
            return 0;
        }

        public string Naam()
        {
            return "Salto";
        }
    }
}
