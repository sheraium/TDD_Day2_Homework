namespace TddDay2
{
    public class PotterShoppingCart
    {
        private int bookAmount = 0;

        public PotterShoppingCart IBuy(string book, int amount)
        {
            this.bookAmount += amount;
            return this;
        }

        public int NeedPay()
        {
            double result = 0;
            double discountRate = 1;

            if (this.bookAmount == 2) discountRate = 0.95;

            result = 100 * this.bookAmount * discountRate;
            return (int)result;
        }
    }
}