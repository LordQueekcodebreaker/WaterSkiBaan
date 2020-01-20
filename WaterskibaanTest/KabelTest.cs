using NUnit.Framework;
using Waterskibaan;

namespace WaterskibaanTest
{
    public class KabelTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerschuifLijnen_Eerstepositieleeg_PositielaatsteAangepast()
        {
            //arrange
            Kabel kabel = new Kabel();
            kabel.NeemLijnInGebruik(new Lijn());
            //act
            kabel.VerschuifLijnen();
            int result = kabel.Lijnen.Last.Value.PositieOpDeLijn;
            //assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void VerschuifLijnen_LaatstePositiegevuld_eerstepositieWordtgevuld()
        {
            //arrange
            Kabel kabel = new Kabel();
            for (int i = 0; i < 10; i++)
            {
                kabel.ToevoegenAanLijst(new Lijn(i));
            }
            //act
            kabel.VerschuifLijnen();
            int result = kabel.Lijnen.First.Value.PositieOpDeLijn;
            int lastValue = kabel.Lijnen.Last.Value.PositieOpDeLijn;
            //assert
            Assert.AreEqual(0, result);
            Assert.AreEqual(9, lastValue);

        }

        [TestCase(0,false)]
        [TestCase(1, true)]
        public void IsStartPositieLeeg_PositieisLeeg_ReturnsTrue(int positie, bool result)
        {
            //arrange
            Kabel kabel = new Kabel();
            //act
            kabel.ToevoegenAanLijst(new Lijn(positie));
            //assert
            bool testresult = kabel.IsStartPositieLeeg();
            Assert.AreEqual(result, testresult);
        }
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        public void NeemLijnInGebruik_POsitieleeg_ListIsChanged(int positie, int count)
        {
            //arrange
            Kabel kabel = new Kabel();
            kabel.ToevoegenAanLijst(new Lijn(positie));
            //act
            kabel.NeemLijnInGebruik(new Lijn());
            int countlist = kabel.Lijnen.Count;
            //assert
            Assert.AreEqual(count, countlist);

        }

        [Test]
        public void VerwijderLijnVanKabel_LastPositionFilled_ListCountDecreases()
        {
            //arrange
            Kabel kabel = new Kabel();
            for (int i = 0; i < 10; i++)
            {
                kabel.ToevoegenAanLijst(new Lijn(i));
            }
            //act
            Lijn testLijn = kabel.VerwijderLijnVanKabel();
            
            //assert
            Assert.IsNotNull(testLijn);
        }

        //[Test]
        //public void Test5()
        //{
        //    //arrange
        //    //act
        //    //assert
        //}

    }
}