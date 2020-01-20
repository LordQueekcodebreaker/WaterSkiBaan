
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
            Game game = new Game();
            game.Intialize();
            game.StartTimer(100);
        }
    }
}
