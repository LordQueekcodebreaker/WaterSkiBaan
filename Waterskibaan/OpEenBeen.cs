using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
   public class OpEenBeen : IMoves
    {
        public int Move()
        {
            return 1;
        }

        public string Naam()
        {
            return "Op een been skieën";
        }
    }
}
