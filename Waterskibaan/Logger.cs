using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Logger
    {
        private Kabel _kabellogger;
        public List<Sporter> Logging = new List<Sporter>() { };
        public int AantalRondjesTotaal { get; set; }

        public Logger(Kabel kabel)
        {
            _kabellogger = kabel;
        }

        public void GooiSportersinLijst(Sporter sp)
        {
            Logging.Add(sp);
            AantalRondjesTotaal += sp.AantalRondesTeGaan;
        }

        public int AantalBezoekersInTotaal()
        {
            return Logging.Count;
        }
        public int HoogsteScoreMoves()
        {
            return Logging.Max(s => s.BehaaldePunten);
        }
        public int TelrodeSporters()
        {
            return Logging.Count(b => IsColorRed(Color.FromArgb(b.KledingKleur.Item1,b.KledingKleur.Item2,b.KledingKleur.Item3)));

        }
        public int TotaalAantalRondjes()
        {
            return AantalRondjesTotaal;
        }

        public List<Color> TienLichtsteKleuren()
        {

            return Logging.OrderByDescending(b => GetColorSize(Color.FromArgb(b.KledingKleur.Item1, b.KledingKleur.Item2, b.KledingKleur.Item3)))
                .Select(b => Color.FromArgb(b.KledingKleur.Item1, b.KledingKleur.Item2, b.KledingKleur.Item3))
                .Take(10)
                .ToList();
        }

        public List<string> UniekeMoves()
        {
            return (from lijn in _kabellogger.Lijnen
                    from move in lijn.Sporter.Moves
                    select move.Naam())
                   .Distinct()
                   .ToList();
        }

        public string PrintGedeelte()
        {
            String zin = "";
            foreach (var letter in Logging)
            {
                zin += letter.ToString();
            }
            return zin;
        }
        private static bool IsColorRed(Color a)
        {
            return ColorsAreClose(a, Color.Red);
        }

        private static bool ColorsAreClose(Color a, Color z, int threshold = 100) //  was 50, 100 van gemaakt om meer rode sporters te krijgen, was diep triest weinig
        {
            int r = a.R - z.R,
                g = a.G - z.G,
                b = a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        private long GetColorSize(Color color)
        {
            return color.R * color.R + color.G * color.G + color.B * color.B;
        }
    }
}
