using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Waterskibaan;

namespace WaterskibaanTest
{
    [TestFixture]
    class WaterskibaanKlasseTest
    {
        [Test]
        public void SporterStart_NoSKiesORvest_ThrowException()
        {
            //arrange
            Waterskibaan.Waterskibaan waterskibaan = new Waterskibaan.Waterskibaan();
            //assert
            Assert.Throws<Exception>(() => waterskibaan.SporterStart(new Sporter(MoveCollection.GetWillekeurigeMoves())));
            //TODO: add a Assert check for exceptions
        }
    [Test]
        public void SporterStart_AllRequirements_SporteraddedToKabel()
        {
            //arrange
            Waterskibaan.Waterskibaan waterskibaan = new Waterskibaan.Waterskibaan();
            //act
            waterskibaan.SporterStart(new Sporter(MoveCollection.GetWillekeurigeMoves()) { Skies = new Skies() , Zwemvest = new Zwemvest()});
            //assert
            int result = waterskibaan._kabel.Lijnen.Count;
            Assert.AreEqual(1, result);
        }




    }
}
