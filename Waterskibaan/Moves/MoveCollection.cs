using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class MoveCollection
    {
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> Moves = new List<IMoves>() { new OpEenBeen(), new Salto(), new Koprol() };
            var LijstmetBewegingen = new List<IMoves>();
            var random = new Random();
            var aantalbewegingen = random.Next(1, Moves.Count + 1);
            for (var i = 0; i < aantalbewegingen; i++)
            {
                LijstmetBewegingen.Add(Moves[i]);
            }
            return LijstmetBewegingen;
        }
    }
}
