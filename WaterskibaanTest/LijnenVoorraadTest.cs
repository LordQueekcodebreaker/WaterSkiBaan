using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Waterskibaan;

namespace WaterskibaanTest
{
    [TestFixture]
    class LijnenVoorraadTest
    {
        [Test]
        public void LijnToevoegenAanRij_EnptyList_CountLIstIncreases()
        {
            //arrange
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            //act
            int listcount = lijnenVoorraad.GetAantalLijnen();
            //assert
            Assert.AreEqual(1, listcount);
        }

        [Test]
        public void VerwijderEersteLijn_LijnenvoorraadisEmpty_ReturnsNull()
        {
            //arrange
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            //act
            var result = lijnenVoorraad.VerwijderEersteLijn();
            //assert
            Assert.IsNull(result);
        }

        [Test]
        public void VerwijderEersteLijn_LijnenvoorraadisNotEmpty_ReturnsLijn()
        {
            //arrange
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            //act
            var result = lijnenVoorraad.VerwijderEersteLijn();
            //assert
            Assert.IsNotNull(result);
        }
    }
}
