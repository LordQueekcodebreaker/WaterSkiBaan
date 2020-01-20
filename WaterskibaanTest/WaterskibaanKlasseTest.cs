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
        public void SporterStart_NoSKiesORvest_ThrowException()
        {
            //arrange
            Waterskibaan.Waterskibaan waterskibaan = new Waterskibaan.Waterskibaan();
            //act
            waterskibaan.SporterStart(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            //assert
            //TODO: add a Assert check for exceptions
        }
    }
}
