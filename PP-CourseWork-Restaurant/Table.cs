using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Restaurant
{
    class Table
    {
        public List<Order> Orders { get; }

        public Table()
        {
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
       {
            Orders.Add(order);
        }
    }
}
