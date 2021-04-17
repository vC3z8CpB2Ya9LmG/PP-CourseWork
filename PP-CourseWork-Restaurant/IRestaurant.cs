using PP_CourseWork_Restaurant.Product;

namespace PP_CourseWork_Restaurant
{
    internal interface IRestaurant
    {
        public void AddProductToMenu(ProductCategory productCategory, string productName, int amount, decimal price);

        public void MakeNewOrder(int tableNumber, params AProduct[] products);

        public void PrintSellsStatistics();

        public void CloseTheDay();
        

    }
}