using PP_CourseWork_Restaurant.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Restaurant
{
    class Statistics { 
        public int TotalTablesOccupied { get; set; }
        public int TotalSellsCount { get; set; }
        public decimal TotalSells { get; set; }
        public Dictionary<String, ByCategoryStatistics> ByCategory { get; set; }

        public Statistics()
        {
            TotalTablesOccupied = 0;
            TotalSellsCount = 0;
            TotalSells = 0m;
            ByCategory = new Dictionary<string, ByCategoryStatistics>();
        }

        internal void Update(Order order)
        {
            TotalSellsCount += order.Products.Length;
            foreach (AProduct prod in order.Products)
            {
                TotalSells += prod.Price;
                String category = ((ProductCategory)prod).Name;
                if (!ByCategory.ContainsKey(category))
                {
                    ByCategory.Add(category, new ByCategoryStatistics(1, prod.Price));
                }
                else
                {
                    ByCategory[category].ProductsCount++;
                    ByCategory[category].Price += prod.Price;
                }
            }
        }

        internal void Update(Table table)
        {
            TotalTablesOccupied++;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format(Constants.Messages.TOTAL_TABLES_OCCUPIED + "\n", TotalTablesOccupied))
                .Append(string.Format(Constants.Messages.TOTAL_SELLS + "\n", TotalSellsCount, TotalSells))
                .Append(Constants.Messages.BY_CATEGORY_LABEL + "\n");
            foreach (String key in ByCategory.Keys)
            {
                result.Append(String.Format(Constants.Messages.BY_CATEGORY_STATS + "\n", key, ByCategory[key].ProductsCount, ByCategory[key].Price));
            }
            return result.ToString();
        }

        public class ByCategoryStatistics
        {
            public int ProductsCount { get; set; }
            public decimal Price { get; set; }

            public ByCategoryStatistics(int productsCount, decimal price)
            {
                ProductsCount = productsCount;
                Price = price;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1:F2}", ProductsCount, Price);
            }

        }
    }
}
