using PP_CourseWork_Restaurant.Product;
using System.Collections.Generic;

namespace PP_CourseWork_Restaurant
{
    class Order
    {
        public AProduct[] Products { get; }

        private Order(AProduct[] products)
        {
            Products = products;
        }

        public static Order CreateOrder(AProduct[] products)
        {
            List<AProduct> availableProducts = new List<AProduct>();
            foreach (AProduct product in products)
            {
                if (Restaurant.GetInstance().Menu.AvailableProducts.ContainsKey(product.Name))
                {
                    availableProducts.Add(product);
                }
            }
            return availableProducts.Count > 0 ? new Order(availableProducts.ToArray()) : null;
        }
    }
}
