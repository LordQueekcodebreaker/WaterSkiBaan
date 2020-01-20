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
            return 5;
        }

        public string Naam()
        {
            return "Koprol";
        }
    }
}
