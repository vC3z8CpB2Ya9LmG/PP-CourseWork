
namespace PP_CourseWork_Restaurant.Product
{
    abstract class ACaloricProduct : AProduct
    {
        public double Calories { get; }

        protected ACaloricProduct(string name, decimal price, int amount, float index) : base(name, price)
        {
            Calories = CalculateCalories(amount, index);
        }

        protected double CalculateCalories(int amount, float index)
        {
            return amount * index;
        }
    }
}
