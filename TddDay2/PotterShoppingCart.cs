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
            //�p�ⳣ�O�楻�S���馩
            decimal minPay = this.orderedBooks.Values.Sum() * 100;
            
            //�̾ڧ馩�ѥ��� �p��զX ����̧C������
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

            //�Y�����ѥ����⥻�H�W�������ѥ��ƶq
            while (amountArray.Min() > 1)
            {
                for (int i = 0; i < amountArray.Length; i++)
                {
                    amountArray[i]--;
                }

                combination.Add(amountArray.Length);
            }

            //�p��ѥ��զX
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