using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Galaxy
{
    class Constants
    {
        public static class Config
        {
           public const bool SKIP_ORIGIN_UNIT_VALIDATION = false;
        }
        public static class Messages
        {
            public const string INVALID_PLANET_TYPE = "Invalid planet type: {0}";
            public const string MISSING_ORIGIN = "No data for {0}";
            public const string STATS_START = "--- Stats ---";
            public const string STATS_GALAXIES = "Galaxies: ";
            public const string STATS_STARS = "Stars: ";
            public const string STATS_PLANETS = "Planets: ";
            public const string STATS_MOONS = "Moons: ";
            public const string STATS_END = "--- End of stats ---";

            public const string DETAILS_GALAXY = "Type: {0}\nAge: {1:F2}{2}";
            public const string DETAILS_STAR = "Name: {0}\nClass: {1} ({2:F2}, {3:F2}, {4}, {5:F2})";
            public const string DETAILS_PLANET = "Name: {0}\nType: {1}\nSupport life: {2}";
            public const string DETAILS_MOON = "{0}";

            public const string YES = "yes";
            public const string NO = "no";

            public const string STATISTICS_STRUCTURE_BY_GALAXY =
                "--- Data for {0} galaxy ---\n{1}\n{2}--- End of data for {0} galaxy ---";
        }
    }
}
