using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Restaurant.Product
{
    class MainCourse : ACaloricProduct
    {
        public int Grams { get; }

        public MainCourse(string name, decimal price, int grams) : base(name, price, grams, 1)
        {
            Grams = grams;
        }

    }
}
