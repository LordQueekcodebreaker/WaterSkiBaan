﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        public Kabel _kabel = new Kabel();
        public LijnenVoorraad _lijnenVoorraad = new LijnenVoorraad();

        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                _lijnenVoorraad.LijnToevoegenAanRij(new Lijn(i + 1));
            }
        }

        public void SporterStart(Sporter sp)
        {
            if (sp.Zwemvest == null || sp.Skies == null)
            {
                throw new Exception("Een sporter behoort een Zwemvest EN Skies te hebben!");
            }
            if (_kabel.IsStartPositieLeeg() == true)
            {
                var getLijn = _lijnenVoorraad.VerwijderEersteLijn();

                getLijn.Sporter = sp;

                _kabel.NeemLijnInGebruik(getLijn);
            }
            else
            {
                return;
            }
        }

        public void VerplaatsKabel()
        {
            _kabel.VerschuifLijnen();
            var verwijderdelijn = _kabel.VerwijderLijnVanKabel();
            if (verwijderdelijn != null)
            {
                _lijnenVoorraad.LijnToevoegenAanRij(verwijderdelijn);
            }
        }

        public void MoveUitvoeren()
        {
            foreach (var lijn in _kabel.Lijnen)
            {
                var sporter = lijn.Sporter;

                if (sporter.Moves.Count > 0)
                {
                    int movePoints = sporter.HuidigeMove.Move();
                    if (movePoints > 0)
                    {
                        sporter.BehaaldePunten += movePoints;
                        sporter.HuidigeMove = sporter.Moves.Last();
                        sporter.Moves.RemoveAt(sporter.Moves.Count - 1);
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Lijnvoorraad: {_lijnenVoorraad.ToString()}\nKabelbezetting: {_kabel.ToString()}";
        }
    }
}
