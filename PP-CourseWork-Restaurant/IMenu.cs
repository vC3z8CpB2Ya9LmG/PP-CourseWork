using PP_CourseWork_Restaurant.Product;

namespace PP_CourseWork_Restaurant
{
    interface IMenu
    {
        public void AddProductToMenu(AProduct product);

        public void AddProductToMenu(ProductCategory productCategory, string productName, int amount, decimal price);

        public AProduct GetProductByName(string name);

    }
}
