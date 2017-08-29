using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddDay2
{
    using System.Runtime.InteropServices;

    [TestClass]
    public class PotterShoppingCartTests
    {
        Book HarryPotter1 = new Book() { Name = "Harry Potter 1", ISBN = "0001" };
        Book HarryPotter2 = new Book() { Name = "Harry Potter 2", ISBN = "0002" };
        Book HarryPotter3 = new Book() { Name = "Harry Potter 3", ISBN = "0003" };
        Book HarryPotter4 = new Book() { Name = "Harry Potter 4", ISBN = "0004" };
        Book HarryPotter5 = new Book() { Name = "Harry Potter 5", ISBN = "0005" };

        [TestMethod]
        public void IBuyAndNeedPayTest_第一集買一本_價格100元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut.IBuy(HarryPotter1, 1).NeedPay();

            var expected = 100;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二集各買一本_價格190元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy(HarryPotter1, 1)
                .IBuy(HarryPotter2, 1)
                .NeedPay();

            var expected = 190;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二三集各買一本_價格270元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy(HarryPotter1, 1)
                .IBuy(HarryPotter2, 1)
                .IBuy(HarryPotter3, 1)
                .NeedPay();

            var expected = 270;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二三四集各買一本_價格320元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy(HarryPotter1, 1)
                .IBuy(HarryPotter2, 1)
                .IBuy(HarryPotter3, 1)
                .IBuy(HarryPotter4, 1)
                .NeedPay();

            var expected = 320;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二三四五集各買一本_價格375元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy(HarryPotter1, 1)
                .IBuy(HarryPotter2, 1)
                .IBuy(HarryPotter3, 1)
                .IBuy(HarryPotter4, 1)
                .IBuy(HarryPotter5, 1)
                .NeedPay();

            var expected = 375;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一二集各買一本And三集買兩本_價格370元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy(HarryPotter1, 1)
                .IBuy(HarryPotter2, 1)
                .IBuy(HarryPotter3, 2)
                .NeedPay();

            var expected = 370;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_一集買一本And二集買兩本And三集買兩本_價格460元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy(HarryPotter1, 1)
                .IBuy(HarryPotter2, 2)
                .IBuy(HarryPotter3, 2)
                .NeedPay();

            var expected = 460;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_選便宜算法_第1_2_3_4_5集買2_2_2_1_1本_價格640元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy(HarryPotter1, 2)
                .IBuy(HarryPotter2, 2)
                .IBuy(HarryPotter3, 2)
                .IBuy(HarryPotter4, 1)
                .IBuy(HarryPotter5, 1)
                .NeedPay();

            var expected = 640;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_第一集重複買兩次一本_價格200元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy(HarryPotter1, 1)
                .IBuy(HarryPotter1, 1)
                .NeedPay();

            var expected = 200;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IBuyAndNeedPayTest_選便宜算法_第1_2_3_4_5集買4_4_4_3_3本_價格1390元()
        {
            var sut = new PotterShoppingCart();

            var actual = sut
                .IBuy(HarryPotter1, 4)
                .IBuy(HarryPotter2, 4)
                .IBuy(HarryPotter3, 4)
                .IBuy(HarryPotter4, 3)
                .IBuy(HarryPotter5, 3)
                .NeedPay();

            var expected = 1390;
            Assert.AreEqual(expected, actual);
        }
    }
}