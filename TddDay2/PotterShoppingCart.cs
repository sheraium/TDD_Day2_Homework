namespace TddDay2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PotterShoppingCart
    {
        private readonly Dictionary<int, decimal> discountRate = new Dictionary<int, decimal>()
        {
            { 1, 1 },
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

            //取得可能的折扣排列組合
            var discountCombinations = GetCombination();

            //計算費用 取最低價錢
            foreach (var combination in discountCombinations)
            {
                decimal sum = 0;
                foreach (var discounter_amount in combination)
                {
                    sum += 100 * discounter_amount.Key * discounter_amount.Value * GetDiscountRate(discounter_amount.Key);
                }
                minPay = Math.Min(minPay, sum);
            }

            return minPay;
        }

        //key=有折扣的書本數, value=該折扣書本數有的數量
        private IEnumerable<Dictionary<int, int>> GetCombination()
        {
            //取得可以折扣的基數
            var discounters = this.discountRate.Keys.ToArray();
            //全部書本數
            var allBooks = this.orderedBooks.Values.Sum();

            List<Dictionary<int, int>> allCombinations =new List<Dictionary<int, int>>();
            Dictionary<int,int> eachCombination = new Dictionary<int, int>();
            
            for (int i = 0; i <= allBooks; i++)
            {
                for (int j = 0; j <= allBooks; j++)
                {
                    for (int k = 0; k <= allBooks; k++)
                    {
                        for (int l = 0; l < allBooks; l++)
                        {
                            for (int m = 0; m < allBooks; m++)
                            {
                                if ((discounters[0] * i + discounters[1] * j + discounters[2] * k + discounters[3] * l + discounters[4] * m) == allBooks)
                                {
                                    eachCombination.Add(discounters[0], i);
                                    eachCombination.Add(discounters[1], j);
                                    eachCombination.Add(discounters[2], k);
                                    eachCombination.Add(discounters[3], l);
                                    eachCombination.Add(discounters[4], m);

                                    //驗證組合
                                    if (ValidateCombination(eachCombination))
                                    {
                                        allCombinations.Add(eachCombination);
                                    }
                                    eachCombination = new Dictionary<int, int>();
                                }
                            }
                        }
                    }
                }
            }

            return allCombinations ;
        }

        private bool ValidateCombination(Dictionary<int, int> combination)
        {
            //取得每本書的數量陣列 同本書最大數量的先取 所以遞減排序
            int[] amountArray = this.GetOrderedBooksAmountToList().OrderByDescending(x => x).ToArray();
            //有幾本不同書
            int maxDifferentBooks = this.orderedBooks.Count;

            //實際取數 驗證組合 key=4, value=2 表示 不同的4本書要取2次
            foreach (var discounter in combination.Keys)
            {
                var takeCount = combination[discounter];//當前折扣的書本數要取幾次
                if (takeCount == 0)//次數為0的跳過
                    continue;
                if(discounter > maxDifferentBooks)//每次取的書本數不能超過 當前剩餘的不同書本數
                {
                    return false;
                }

                //折扣的書本數 取書迴圈
                for (int i = 0; i < takeCount; i++)
                {
                    var take = discounter;//折扣的書本數
                    //取折扣的書本數 迴圈
                    for (int j = 0; j < maxDifferentBooks; j++)
                    {
                        if (take > 0)
                        {
                            amountArray[j]--;
                            take--;
                        }
                    }
                    if (take > 0) return false;//確定取足了
                    //消除取完的書
                    amountArray = amountArray.Where(x => x > 0).Select(x => x).OrderByDescending(x => x).ToArray();
                    //更新當前書的種類數
                    maxDifferentBooks = amountArray.Length;
                }
            }
            //確認全部書都取完了
            if (amountArray.Sum(x => x) == 0)
                return true;

            return false;
        }

        private decimal GetDiscountRate(int booksAmount)
        {
            if (this.discountRate.ContainsKey(booksAmount))
            {
                return this.discountRate[booksAmount];
            }
            return 1;
        }

        private IEnumerable<int> GetOrderedBooksAmountToList()
        {
            return new List<int>(this.orderedBooks.Values.ToArray());
        }
    }
}