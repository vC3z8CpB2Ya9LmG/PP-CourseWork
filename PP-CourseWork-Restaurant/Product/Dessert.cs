using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Restaurant.Product
{
    class Dessert : ACaloricProduct
    {
        public int Grams { get; }

        public Dessert(string name, decimal price, int grams) : base(name, price, grams, 3)
        {
            Grams = grams;
        }

    }
}
