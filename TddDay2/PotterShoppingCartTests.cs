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
    }
}