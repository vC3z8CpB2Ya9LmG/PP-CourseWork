using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Restaurant.Product
{
    class Drink : ACaloricProduct
    {
        public int Milliliters { get; }

        public Drink(string name, decimal price, int milliliters) : base(name, price, milliliters, 1.5f)
        {
            Milliliters = milliliters;
        }
    }
}
