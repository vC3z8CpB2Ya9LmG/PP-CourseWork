using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace PP_CourseWork_Galaxy
{
    class StarClass
    {
        public static readonly StarClass O = new StarClass("O", 30_000, int.MaxValue, 30_000f, float.MaxValue, 16f, float.MaxValue, 6.6f, float.MaxValue);
        public static readonly StarClass B = new StarClass("B", 10_000, 30_000, 25f, 30_000f, 2.1f, 16, 1.8f, 6.6f);
        public static readonly StarClass A = new StarClass("A", 7_500, 10_000, 5f, 25f, 1.4f, 2.1f, 1.4f, 1.8f);
        public static readonly StarClass F = new StarClass("F", 6_000, 7_500, 1.5f, 5f, 1.04f, 1.4f, 1.15f, 1.4f);
        public static readonly StarClass G = new StarClass("G", 5_200, 6_000, 0.6f, 1.5f, 0.8f, 1.04f, 0.96f, 1.15f);
        public static readonly StarClass K = new StarClass("K", 3_700, 5_200, 0.08f, 0.6f, 0.45f, 0.8f, 0.7f, 0.96f);
        public static readonly StarClass M = new StarClass("M", 2_400, 3_700, float.MinValue, 0.08f, 0.08f, 0.45f, float.MinValue, 0.7f);

        public string Name;
        public int MinTemperature;
        public int MaxTemperature;
        public float MinLuminosity;
        public float MaxLuminosity;
        public float MinMass;
        public float MaxMass;
        public float MinRadius;
        public float MaxRadius;

        private StarClass(string name,  int minTemperature, int maxTemperature, float minLuminosity, float maxLuminosity, float minMass, float maxMass, float minRadius, float maxRadius)
        {
            Name = name;
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            MinLuminosity = minLuminosity;
            MaxLuminosity = maxLuminosity;
            MinMass = minMass;
            MaxMass = maxMass;
            MinRadius = minRadius;
            MaxRadius = maxRadius;
        }

        public static StarClass ClassifyStarClass(Star star)
        {
            FieldInfo[] fields = typeof(StarClass).GetFields();

            List<FieldInfo> fieldsList = new List<FieldInfo>(fields);
            fieldsList = fieldsList.FindAll(g => g.IsStatic && g.IsPublic && g.DeclaringType.Name.Equals("StarClass") );
            foreach (var field in fieldsList)
            {
                StarClass starClass = (StarClass)field.GetValue(field);
                if(star.Temperature >= starClass.MinTemperature && star.Temperature <= starClass.MaxTemperature &&
                    star.Luminosity >= starClass.MinLuminosity && star.Luminosity <= starClass.MaxLuminosity &&
                    star.Mass >= starClass.MinMass && star.Mass <= starClass.MaxMass &&
                    star.Size/2 >= starClass.MinRadius && star.Size/2 <= starClass.MaxRadius)
                {
                    return starClass;
                }
            }
            return null;
        }
    }
}
