namespace TddDay2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PotterShoppingCart
    {
        private readonly Dictionary<int, decimal> discountRate = new Dictionary<int, decimal>()
        {
            { 2, 0.95m },
            { 3, 0.9m },
            { 4, 0.8m },
            { 5, 0.75m },
        };

        private readonly Dictionary<string, int> orderedBooks = new Dictionary<string, int>();

        public PotterShoppingCart IBuy(Book book, int amount)
        {
            if (this.orderedBooks.ContainsKey(book.ISBN))
                this.orderedBooks[book.ISBN] += amount;
            else
                this.orderedBooks[book.ISBN] = amount;
            return this;
        }

        public decimal NeedPay()
        {
            decimal minPay = this.orderedBooks.Values.Sum() * 100;

            int[] sequence = new[] { 5, 4, 3, 2 };

            foreach (var startNumber in sequence)
            {
                var combination = this.GetCombination(startNumber);

                decimal result = 0;
                foreach (var amount in combination)
                {
                    result += 100 * amount * GetDiscountRate(amount);
                }
                minPay = Math.Min(minPay, result);
            }

            return minPay;
        }

        private IEnumerable<int> GetCombination(int startNumber)
        {
            List<int> combination = new List<int>();

            int[] amountArray = this.GetOrderedBooksAmountArray();

            //若全部書本都兩本以上直接取書本數量
            while (amountArray.Min() > 1)
            {
                for (int i = 0; i < amountArray.Length; i++)
                {
                    amountArray[i]--;
                }

                combination.Add(amountArray.Length);
            }

            //計算書本組合
            while (amountArray.Any(amount => amount > 0))
            {
                int booksAmount = 0;
                for (int i = 0; i < startNumber; i++)
                {
                    if (i < amountArray.Length)
                    {
                        booksAmount++;
                        amountArray[i]--;
                    }
                }
                combination.Add(booksAmount);
                amountArray = amountArray.Where(x => x > 0).Select(x => x).ToArray();
            }
            return combination;
        }

        private decimal GetDiscountRate(int booksAmount)
        {
            if (this.discountRate.ContainsKey(booksAmount))
            {
                return this.discountRate[booksAmount];
            }
            return 1;
        }

        private int[] GetOrderedBooksAmountArray()
        {
            var booksAmountArray = new int[this.orderedBooks.Count];
            Array.Copy(this.orderedBooks.Values.ToArray(), booksAmountArray, this.orderedBooks.Count);
            return booksAmountArray;
        }
    }
}