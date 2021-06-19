using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Galaxy
{
    class Galaxy : SpaceUnit
    {
        public GalaxyType GalaxyType { get; }
        public GalaxyAge Age { get; }

        public Dictionary<String, Star> StarsByName { get; }

        public Galaxy(string Name, GalaxyType GalaxyType, GalaxyAge Age) : base(Name)
        {
            this.Age = Age;
            this.GalaxyType = GalaxyType;
            StarsByName = new Dictionary<string, Star>();
        }

        public void AddStar(Star star)
        {
            StarsByName.Add(star.Name, star);
        }

        public override string Stats()
        {
            return string.Format(Constants.Messages.DETAILS_GALAXY, GalaxyType, Age.age, Age.unit);
        }

        public struct GalaxyAge
        {
            public float age;
            public string unit;

            public GalaxyAge(float age, string unit)
            {
                this.age = age;
                this.unit = unit;
            }

            public override string ToString()
            {
                return age + unit;
            }
        }
    }
}
