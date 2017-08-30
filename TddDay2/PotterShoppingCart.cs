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
            //�p�ⳣ�O�楻�S���馩
            decimal minPay = this.orderedBooks.Values.Sum() * 100;

            //���o�i�઺�馩�ƦC�զX
            var discountCombinations = GetCombination();

            //�p��O�� ���̧C����
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

        //key=���馩���ѥ���, value=�ӧ馩�ѥ��Ʀ����ƶq
        private IEnumerable<Dictionary<int, int>> GetCombination()
        {
            //���o�i�H�馩�����
            var discounters = this.discountRate.Keys.ToArray();
            //�����ѥ���
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

                                    //���ҲզX
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
            //���o�C���Ѫ��ƶq�}�C �P���ѳ̤j�ƶq������ �ҥH����Ƨ�
            int[] amountArray = this.GetOrderedBooksAmountToList().OrderByDescending(x => x).ToArray();
            //���X�����P��
            int maxDifferentBooks = this.orderedBooks.Count;

            //��ڨ��� ���ҲզX key=4, value=2 ��� ���P��4���ѭn��2��
            foreach (var discounter in combination.Keys)
            {
                var takeCount = combination[discounter];//��e�馩���ѥ��ƭn���X��
                if (takeCount == 0)//���Ƭ�0�����L
                    continue;
                if(discounter > maxDifferentBooks)//�C�������ѥ��Ƥ���W�L ��e�Ѿl�����P�ѥ���
                {
                    return false;
                }

                //�馩���ѥ��� ���Ѱj��
                for (int i = 0; i < takeCount; i++)
                {
                    var take = discounter;//�馩���ѥ���
                    //���馩���ѥ��� �j��
                    for (int j = 0; j < maxDifferentBooks; j++)
                    {
                        if (take > 0)
                        {
                            amountArray[j]--;
                            take--;
                        }
                    }
                    if (take > 0) return false;//�T�w�����F
                    //������������
                    amountArray = amountArray.Where(x => x > 0).Select(x => x).OrderByDescending(x => x).ToArray();
                    //��s��e�Ѫ�������
                    maxDifferentBooks = amountArray.Length;
                }
            }
            //�T�{�����ѳ������F
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