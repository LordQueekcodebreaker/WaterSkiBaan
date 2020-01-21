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


    }
}
