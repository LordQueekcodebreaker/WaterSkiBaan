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
            return 2;
        }

        public string Naam()
        {
            return "Salto";
        }
    }
}
