using System;
using System.Collections.Generic;
using System.Text;
using PP_CourseWork_Restaurant.Product;

namespace PP_CourseWork_Restaurant
{
    public class ProductFactory
    {

        public static ProductFactory Instance = new ProductFactory();

        private ProductFactory() { }

        public AProduct CreateProduct(ProductCategory productCategory, String name, int amount, decimal price)
        {
            return productCategory.Name switch
            {
                Constants.ProductCategory.DESSERT => new Dessert(name, price, amount),
                Constants.ProductCategory.DRINK => new Drink(name, price, amount),
                Constants.ProductCategory.MAIN_COURSE => new MainCourse(name, price, amount),
                Constants.ProductCategory.SALAD => new Salad(name, price, amount),
                Constants.ProductCategory.SOUP => new Soup(name, price, amount),
                _ => null,
            };
        }
    }
}
