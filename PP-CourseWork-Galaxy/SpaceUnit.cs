using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Galaxy
{
    abstract class SpaceUnit
    {
        public string Name { get; }

        protected SpaceUnit(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Stats();
        }

        public abstract string Stats();
    }
}
