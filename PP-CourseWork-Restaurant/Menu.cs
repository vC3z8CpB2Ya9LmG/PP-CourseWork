using System;
using System.Collections.Generic;
using PP_CourseWork_Restaurant.Product;

namespace PP_CourseWork_Restaurant
{
    class Menu : IMenu
    {
        public Dictionary<string, AProduct> AvailableProducts { get; }

        public Menu()
        {
            AvailableProducts = new Dictionary<string, AProduct>();
        }

        public void AddProductToMenu(AProduct aProduct)
        {
            AvailableProducts.Add(aProduct.Name, aProduct);
        }

        public void AddProductToMenu(ProductCategory productCategory, string productName, int amount, decimal price)
        {
            AProduct product;
            switch (productCategory.Name)
            {
                case Constants.ProductCategory.SOUP:
                    product = new Soup(productName, price, amount); break;
                case Constants.ProductCategory.SALAD:
                    product = new Salad(productName, price, amount); break;
                case Constants.ProductCategory.MAIN_COURSE:
                    product = new MainCourse(productName, price, amount); break;
                case Constants.ProductCategory.DRINK:
                    product = new Drink(productName, price, amount); break;
                case Constants.ProductCategory.DESSERT:
                    product = new Dessert(productName, price, amount); break;
                default:
                    Console.WriteLine(Constants.Messages.INVALID_INPUT); return;
            }
            AddProductToMenu(product);
        }

        public AProduct GetProductByName(string name)
        {
            return AvailableProducts[name];
        }
    }
}
