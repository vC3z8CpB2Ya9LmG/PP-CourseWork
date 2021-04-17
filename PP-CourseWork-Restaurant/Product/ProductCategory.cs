using System;
using System.Collections.Generic;
using PP_CourseWork_Restaurant.Product;

namespace PP_CourseWork_Restaurant
{
    public class ProductCategory
    {
        public static readonly ProductCategory SALAD = new ProductCategory(Constants.ProductCategory.SALAD);
        public static readonly ProductCategory SOUP = new ProductCategory(Constants.ProductCategory.SOUP);
        public static readonly ProductCategory MAIN_COURSE = new ProductCategory(Constants.ProductCategory.MAIN_COURSE);
        public static readonly ProductCategory DESSERT = new ProductCategory(Constants.ProductCategory.DESSERT);
        public static readonly ProductCategory DRINK = new ProductCategory(Constants.ProductCategory.DRINK);

        public ProductCategory(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static explicit operator ProductCategory(AProduct product)
        {
            if (product is Soup) return SOUP;
            if (product is Drink) return DRINK;
            if (product is Salad) return SALAD;
            if (product is Dessert) return DESSERT;
            if (product is MainCourse) return MAIN_COURSE;
            return null;
        }

        public static explicit operator ProductCategory(string name)
        {
            return name switch
            {
                Constants.ProductCategory.DESSERT => DESSERT,
                Constants.ProductCategory.DRINK => DRINK,
                Constants.ProductCategory.MAIN_COURSE => MAIN_COURSE,
                Constants.ProductCategory.SALAD => SALAD,
                Constants.ProductCategory.SOUP => SOUP,
                _ => null
            };
        }

        public static bool operator ==(ProductCategory lpc, ProductCategory rpc)
        {
            if (lpc is null || rpc is null) { return false; }
            return lpc.Name.Equals(rpc.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool operator !=(ProductCategory lpc, ProductCategory rpc) => !(lpc == rpc);

        public static IEnumerable<ProductCategory> Values
        {
            get
            {
                yield return SALAD;
                yield return SOUP;
                yield return MAIN_COURSE;
                yield return DESSERT;
                yield return DRINK;
            }
        }
    }
}
