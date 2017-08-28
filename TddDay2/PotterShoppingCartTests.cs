using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDay2
{
    [TestClass]
    public class PotterShoppingCartTests
    {
        [TestMethod]
        public void IBuyAndNeedPayTest_第一集買一本_價格100元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut.IBuy("Harry Potter 1", 1).NeedPay();

            var expected = 100;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二集各買一本_價格190元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy("Harry Potter 1", 1)
                .IBuy("Harry Potter 2", 1)
                .NeedPay();

            var expected = 190;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二三集各買一本_價格270元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy("Harry Potter 1", 1)
                .IBuy("Harry Potter 2", 1)
                .IBuy("Harry Potter 3", 1)
                .NeedPay();

            var expected = 270;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二三四集各買一本_價格320元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy("Harry Potter 1", 1)
                .IBuy("Harry Potter 2", 1)
                .IBuy("Harry Potter 3", 1)
                .IBuy("Harry Potter 4", 1)
                .NeedPay();

            var expected = 320;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二三四五集各買一本_價格375元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy("Harry Potter 1", 1)
                .IBuy("Harry Potter 2", 1)
                .IBuy("Harry Potter 3", 1)
                .IBuy("Harry Potter 4", 1)
                .IBuy("Harry Potter 5", 1)
                .NeedPay();

            var expected = 375;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二集各買一本And三集買兩本_價格370元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy("Harry Potter 1", 1)
                .IBuy("Harry Potter 2", 1)
                .IBuy("Harry Potter 3", 2)
                .NeedPay();

            var expected = 370;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一集買一本And二集買兩本And三集買兩本_價格460元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy("Harry Potter 1", 1)
                .IBuy("Harry Potter 2", 2)
                .IBuy("Harry Potter 3", 2)
                .NeedPay();

            var expected = 460;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_選便宜算法_第1_2_3_4_5集買2_2_2_1_1本_價格640元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy("Harry Potter 1", 2)
                .IBuy("Harry Potter 2", 2)
                .IBuy("Harry Potter 3", 2)
                .IBuy("Harry Potter 4", 1)
                .IBuy("Harry Potter 5", 1)
                .NeedPay();

            var expected = 640;
            Assert.AreEqual(expected, actual);
        }
    }
}