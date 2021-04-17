using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Restaurant.Product
{
    class Soup : AProduct
    {
        public int Grams { get; }

        public Soup(string name, decimal price, int grams) : base(name, price)
        {

        }
    }
}
