
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
            Waterskibaan waterskibaan = new Waterskibaan();
            for (int i = 0; i < 20; i++)
            {
                waterskibaan.SporterStart(new Sporter(MoveCollection.GetWillekeurigeMoves()) { Skies = new Skies(), Zwemvest = new Zwemvest()});
            }
        }
    }
}
