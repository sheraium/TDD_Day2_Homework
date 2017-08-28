namespace TddDay2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PotterShoppingCart
    {
        private readonly Dictionary<string, int> orderedBooks = new Dictionary<string, int>();

        public PotterShoppingCart IBuy(string book, int amount)
        {
            this.orderedBooks.Add(book, amount);
            return this;
        }

        public int NeedPay()
        {
            var combination = this.GetCombination();

            double result = 0;
            foreach (var amount in combination)
            {
                result += 100 * amount * GetDiscountRate(amount);
            }
            return (int)result;
        }

        private IEnumerable<int> GetCombination()
        {
            List<int> combination = new List<int>();

            int[] amountArray = this.GetOrderedBooksAmountArray();

            while (amountArray.Any(amount => amount > 0))
            {
                int booksAmount = 0;
                for (int i = 0; i < amountArray.Length; i++)
                {
                    if (amountArray[i] > 0)
                    {
                        booksAmount++;
                        amountArray[i]--;
                    }
                }
                combination.Add(booksAmount);
            }
            return combination;
        }

        private double GetDiscountRate(int booksAmount)
        {
            double discountRate;
            switch (booksAmount)
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

                case 5:
                    discountRate = 0.75;
                    break;

                default:
                    discountRate = 1.0;
                    break;
            }

            return discountRate;
        }

        private int[] GetOrderedBooksAmountArray()
        {
            var booksAmountArray = new int[this.orderedBooks.Count];
            Array.Copy(this.orderedBooks.Values.ToArray(), booksAmountArray, this.orderedBooks.Count);
            return booksAmountArray;
        }
    }
}