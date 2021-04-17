
namespace PP_CourseWork_Restaurant.Product
{
    public abstract class AProduct
    {
        public string Name { get; }
        public decimal Price { get; }

        protected AProduct(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
