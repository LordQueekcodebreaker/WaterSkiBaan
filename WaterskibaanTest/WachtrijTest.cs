using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Waterskibaan;

namespace WaterskibaanTest
{
    [TestFixture]
    class WachtrijTest
    {
        [Test]    
        public void SporterNeemtPlaats_MoreSportersStartThenAllowed_listcountisfive()
        {
            //arrange
            InstructieGroep groep = new InstructieGroep();
            //act
            for (int i = 0; i < 10; i++)
            {
                groep.SporterNeemtPlaats(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            }
            int listCount = groep.GetAantal();
            //assert
            Assert.AreEqual(5, listCount);
        }

        [Test]
        public void SportersVerlatenRij_FilledList_ListCountDecreases()
        {
            //arrange
            InstructieGroep groep = new InstructieGroep();
            //act
            for (int i = 0; i < 4; i++)
            {
                groep.SporterNeemtPlaats(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            }
            groep.SportersVerlatenRij(3);
            int listCount = groep.GetAantal();
            //assert
            Assert.AreEqual(1, listCount);
        }

        [Test]
        public void GetAlleSporters_FilledList_ListCountequalsReturnedList()
        {
            //arrange
            InstructieGroep groep = new InstructieGroep();
            //act
            for (int i = 0; i < 4; i++)
            {
                groep.SporterNeemtPlaats(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            }
            int orginalCount = groep.GetAantal();
            List<Sporter> newlist = groep.GetAlleSporters();
            //assert
            Assert.AreEqual(orginalCount, newlist.Count);
        }
    }
}
