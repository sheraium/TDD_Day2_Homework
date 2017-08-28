using System;
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

            var actual = sut.IBuyAndNeedPay("Harry Potter 1", 1);

            var expected = 100;
            Assert.AreEqual(expected, actual);
        }
    }

    public class PotterShoppingCart
    {
        public int IBuyAndNeedPay(string book, int amount)
        {
            throw new NotImplementedException();
        }
    }
}