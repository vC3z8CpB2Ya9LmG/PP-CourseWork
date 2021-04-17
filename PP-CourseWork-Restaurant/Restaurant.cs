using PP_CourseWork_Restaurant.Product;
using System;

namespace PP_CourseWork_Restaurant
{
    class Restaurant : IRestaurant
    {
        public Menu Menu { get; }
        public Table[] Tables { get; }
        public Statistics GeneralStatistics { get; }
        public bool IsOpen { get; set; }
        private static readonly Restaurant restaurant = new Restaurant(Constants.RESTAURANT_TABLES_COUNT);
        public static Restaurant GetInstance()
        {
            return restaurant;
        }

        private Restaurant(int tablesCount)
        {
            Menu = new Menu();
            Tables = new Table[tablesCount];
            GeneralStatistics = new Statistics();
            IsOpen = true;
        }

        public void AddProductToMenu(ProductCategory productCategory, string productName, int amount, decimal price)
        {
            Menu.AddProductToMenu(productCategory, productName, amount,  price);
        }

        public void MakeNewOrder(int tableNumber, AProduct[] products)
        {
            Order order = Order.CreateOrder(products);
            if(order == null)
            {
                return;
            }
            if (Tables[tableNumber - 1] == null)
            {
                Tables[tableNumber - 1] = new Table();
                GeneralStatistics.Update(Tables[tableNumber - 1]);
            }
            Tables[tableNumber - 1].AddOrder(order);
            GeneralStatistics.Update(order);
        }

        public void PrintSellsStatistics()
        {
            Console.WriteLine(GeneralStatistics.ToString());
        }

        public void CloseTheDay()
        {
            PrintSellsStatistics();
            IsOpen = false;
        }

    }
}
