using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Restaurant.Product
{
    class Salad : AProduct
    {

        public int Grams { get; }

        public Salad(string name, decimal price, int grams) : base(name, price)
        {

        }
    }
}
