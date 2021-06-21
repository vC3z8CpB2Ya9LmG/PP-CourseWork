using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Galaxy
{
    class SpaceMap : ISpaceMap
    {
        Dictionary<string, Galaxy> GalaxiesByName = new Dictionary<string, Galaxy>();
        Dictionary<string, Star> StarsByName = new Dictionary<string, Star>();
        Dictionary<string, Planet> PlanetsByName = new Dictionary<string, Planet>();
        Dictionary<string, Moon> MoonsByName = new Dictionary<string, Moon>();

        private static readonly SpaceMap instance = new SpaceMap();
        private SpaceMap(){}
        public static SpaceMap GetInstance()
        {
            return instance;
        }

        public void AddSpaceUnit(string originName, SpaceUnit spaceUnit)
        {
            switch (spaceUnit)
            {
                case Galaxy g:
                    GalaxiesByName.Add(g.Name, g);
                    break;
                case Star s:
                    AddToMap(StarsByName, GalaxiesByName, originName, s);
                    break;
                case Planet p:
                    AddToMap(PlanetsByName, StarsByName, originName, p);
                    break;
                case Moon m:
                    AddToMap(MoonsByName, PlanetsByName, originName, m);
                    break;
                default:
                    break;
            }
        }

        public void AddSpaceUnits(string originName, params SpaceUnit[] spaceUnits)
        {
            foreach (SpaceUnit unit in spaceUnits)
            {
                AddSpaceUnit(originName, unit);
            }
        }

        public ICollection ListSpaceUnitsByType(Type spaceUnitType)
        {
            return spaceUnitType.Name switch
            {
                nameof(Galaxy) => GalaxiesByName.Keys,
                nameof(Star) => StarsByName.Keys,
                nameof(Planet) => PlanetsByName.Keys,
                nameof(Moon) => MoonsByName.Keys,
                _ => new string[0],
            };
        }

        public string GetStatistics()
        {
            return Constants.Messages.STATS_START + "\n" +
                Constants.Messages.STATS_GALAXIES + GalaxiesByName.Count + "\n" +
                Constants.Messages.STATS_STARS + PlanetsByName.Count + "\n" +
                Constants.Messages.STATS_PLANETS + MoonsByName.Count + "\n" +
                Constants.Messages.STATS_MOONS + ListSpaceUnitsByType(typeof(Moon)).Count + "\n" +
                Constants.Messages.STATS_END;
        }

        public string GetStatisticsByGalaxyName(string galaxyName)
        {
            return GalaxiesByName.ContainsKey(galaxyName) ? GetStatisticsByGalaxy(GalaxiesByName[galaxyName]) : Constants.Messages.NONE;
        }

        public string GetStatisticsByGalaxy(Galaxy galaxy)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Constants.Messages.STATS_STARS + (galaxy.Children.Count > 0 ? "" : Constants.Messages.NONE)).Append("\n");
            foreach (string starName in galaxy.Children)
            {
                Star star = StarsByName[starName];
                sb.Append(StarsByName[starName].ToString() + "\n")
                    .Append(Constants.Messages.STATS_PLANETS + (star.Children.Count > 0 ? "" : Constants.Messages.NONE))
                        .Append("\n");
                foreach (string planetName in star.Children)
                {
                    Planet planet = PlanetsByName[planetName];
                    sb.Append(planet.ToString() + "\n")
                        .Append(Constants.Messages.STATS_MOONS + (planet.Children.Count > 0 ? "" : Constants.Messages.NONE))
                            .Append("\n");
                    foreach (string moonName in planet.Children)
                    {
                        Moon moon = MoonsByName[moonName];
                        sb.Append(moon.ToString() + "\n");
                    }
                }
            
            }
            return sb.ToString();
        }


        private static void AddToMap<T,U>(Dictionary<string, T> dictionary, Dictionary<string, U> originDictionary, string originName, T unit) where T : SpaceUnit where U : SpaceUnit
        {

            bool validOrigin = originDictionary.ContainsKey(originName) || Constants.Config.SKIP_ORIGIN_UNIT_VALIDATION;
            if (validOrigin && !dictionary.ContainsKey(unit.Name))
            {
                dictionary[unit.Name] = unit;
                originDictionary[originName].AddChild(unit.Name);
            } else
            {
                Console.WriteLine(String.Format(Constants.Messages.MISSING_ORIGIN, originName, unit.Name));
            }
        }

    }
}
