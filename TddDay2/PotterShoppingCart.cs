namespace TddDay2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PotterShoppingCart
    {
        private int bookAmount = 0;
        readonly Dictionary<string, int> orderedBooks = new Dictionary<string, int>();

        public PotterShoppingCart IBuy(string book, int amount)
        {
            this.bookAmount += amount;
            this.orderedBooks.Add(book, amount);
            return this;
        }

        public int NeedPay()
        {
            double result = 0;
            double discountRate = 1;

            var books = new int[this.orderedBooks.Count];
            Array.Copy(this.orderedBooks.Values.ToArray(), books, this.orderedBooks.Count);
            
            while (books.Any(amount => amount > 0))
            {
                int booksAmount = 0;
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] > 0)
                    {
                        booksAmount++;
                        books[i]--;
                    }
                }

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
                        discountRate = 1d;
                        break;
                }
                result += 100 * booksAmount * discountRate;
            }
            return (int)result;
        }
    }
}