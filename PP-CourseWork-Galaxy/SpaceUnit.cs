using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Galaxy
{
    abstract class SpaceUnit
    {
        public string Name { get; }
        public HashSet<string> Children { get; }

        protected SpaceUnit(string name)
        {
            Name = name;
            Children = new HashSet<string>();
        }

        public override string ToString()
        {
            return Stats();
        }

        public abstract string Stats();
        public void AddChild(string name) {
            Children.Add(name);
        }
    }
}
