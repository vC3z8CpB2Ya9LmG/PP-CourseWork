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
        public static class Functions
        {
            public const string ADD = "add";
            public const string LIST = "list";
            public const string STATS = "stats";
            public const string PRINT = "print";
            public const string EXIT = "exit";

            public static class SPACE_UNIT
            {
                public const string GALAXY = "galaxy";
                public const string STAR = "star";
                public const string PLANET = "planet";
                public const string MOON = "moon";
            }
            public static class SPACE_UNIT_PL
            {
                public const string GALAXIES = "galaxies";
                public const string STARS = "stars";
                public const string PLANETS = "planets";
                public const string MOONS = "moons";
            }
            public static class GALAXY_TYPE
            {
                public const string ELLIPTICAL = "elliptical";
                public const string LENTICULAR = "lenticular";
                public const string SPIRAL = "spiral";
                public const string IRREGULAR = "irregular";
            }
        }
        public static class Messages
        {
            public const string INVALID_PLANET_TYPE = "Invalid planet type: {0}";
            public const string MISSING_ORIGIN = "Error. No data for {0} or {1} is already registered";
            public const string STATS_START = "--- Stats ---";
            public const string STATS_GALAXIES = "Galaxies: ";
            public const string STATS_STARS = "Stars: ";
            public const string STATS_PLANETS = "Planets: ";
            public const string STATS_MOONS = "Moons: ";
            public const string STATS_END = "--- End of stats ---";
            public const string LIST_START = "--- List of all researched {0} ---";
            public const string LIST_END = "--- End of {0} list ---";

            public const string PRINT_GALAXY_START = "--- Data for {0} galaxy ---\n{1}\n";
            public const string PRINT_GALAXY_END = "--- Data for {0} galaxy ---\n{1}\n";

            public const string DETAILS_GALAXY = "Type: {0}\nAge: {1:F2}{2}";
            public const string DETAILS_STAR = "Name: {0}\nClass: {1} ({2:F2}, {3:F2}, {4}, {5:F2})";
            public const string DETAILS_PLANET = "Name: {0}\nType: {1}\nSupport life: {2}";
            public const string DETAILS_MOON = "{0}";

            public const string YES = "yes";
            public const string NO = "no";
            public const string NONE = "none";

            public const string STATISTICS_STRUCTURE_BY_GALAXY =
                "--- Data for {0} {1} ---\n{2}--- End of data for {0} {1} ---";
        }
    }
}
