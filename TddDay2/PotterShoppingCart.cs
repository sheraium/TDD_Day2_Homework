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

            switch (this.bookAmount)
            {
                case 2:
                    discountRate = 0.95;
                    break;

                case 3:
                    discountRate = 0.9;
                    break;

                case 4:
                    discountRate = 0.8;
                    break;
            }

            result = 100 * this.bookAmount * discountRate;
            return (int)result;
        }
    }
}