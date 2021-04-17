using System;
using PP_CourseWork_Restaurant.Product;

namespace PP_CourseWork_Restaurant
{
    class Program
    {
        static void Main()
        {
            RestaurantLauncher();
        }

        public static void RestaurantLauncher()
        {
            Restaurant restaurant = Restaurant.GetInstance();
            while (restaurant.IsOpen)
            {
                string input = Console.ReadLine();
                if(input == null)
                {
                    RestaurantLauncher();
                }
                String[] inputElements = input.Trim().Split(",");
                if (inputElements[0].Equals(Constants.Functions.END))
                {
                    restaurant.CloseTheDay();
                }
                else if (inputElements[0].Equals(Constants.Functions.SELLS))
                {
                    restaurant.PrintSellsStatistics();
                }
                else
                {
                    try
                    {
                        int tableNumber = int.Parse(inputElements[0]);
                        string[] arr = new ArraySegment<string>(inputElements, 0, inputElements.Length - 1).ToArray();
                        AProduct[] products = new AProduct[inputElements.Length-1];
                        for (int i = 1; i < inputElements.Length; i++)
                        {
                            products[i - 1] = restaurant.Menu.GetProductByName(inputElements[i]);
                        }
                        restaurant.MakeNewOrder(tableNumber, products);
                    }
                    catch
                    {
                        foreach (ProductCategory category in ProductCategory.Values)
                        {
                            if (inputElements[0].Equals(category.Name, StringComparison.InvariantCultureIgnoreCase))
                            {
                                restaurant.AddProductToMenu(
                                    category,
                                    inputElements[1],
                                    int.Parse(inputElements[2]),
                                    decimal.Parse(inputElements[3]
                                ));
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
