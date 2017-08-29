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
            //計算都是單本沒有折扣
            decimal minPay = this.orderedBooks.Values.Sum() * 100;
            
            //依據折扣書本數 計算組合 選取最低價錢的
            foreach (var startNumber in this.discountRate.Keys)
            {
                var combination = this.GetCombination(startNumber);
                decimal result = combination.Sum(amount => 100 * amount * GetDiscountRate(amount));
                minPay = Math.Min(minPay, result);
            }

            return minPay;
        }

        private IEnumerable<int> GetCombination(int startNumber)
        {
            List<int> combination = new List<int>();

            int[] amountArray = this.GetOrderedBooksAmountToIntArray();

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

        private int[] GetOrderedBooksAmountToIntArray()
        {
            return new List<int>(this.orderedBooks.Values.ToArray()).ToArray();
        }
    }
}