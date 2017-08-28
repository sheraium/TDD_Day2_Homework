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
            else if (this.bookAmount == 3) discountRate = 0.9;

            result = 100 * this.bookAmount * discountRate;
            return (int)result;
        }
    }
}