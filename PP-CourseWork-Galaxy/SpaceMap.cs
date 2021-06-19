using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Galaxy
{
    class SpaceMap : ISpaceMap
    {
        Dictionary<string, Galaxy> GalaxiesByName = new Dictionary<string, Galaxy>();
        Dictionary<string, List<Star>> StarsByGalaxyName = new Dictionary<string, List<Star>>();
        Dictionary<string, List<Planet>> PlanetsByStarName = new Dictionary<string, List<Planet>>();
        Dictionary<string, List<Moon>> MoonsByPlanetName = new Dictionary<string, List<Moon>>();

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
                    AddToMap(StarsByGalaxyName, GalaxiesByName, originName, s);
                    break;
                case Planet p:
                    AddToMap(PlanetsByStarName, StarsByGalaxyName, originName, p);
                    break;
                case Moon m:
                    AddToMap(MoonsByPlanetName, PlanetsByStarName, originName, m);
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

        public List<string> ListSpaceUnitsByType(Type spaceUnitType)
        {
            List<String> result = new List<string>();
            switch (spaceUnitType.Name)
            {
                case nameof(Galaxy):
                    List<Galaxy> galaxies = new List<Galaxy>(GalaxiesByName.Values);
                    return galaxies.ConvertAll(g => g.Name);
                case nameof(Star):
                    foreach (List<Star> stars in StarsByGalaxyName.Values)
                    {
                        result.AddRange(stars.ConvertAll(g => g.Name));
                    }
                    break;
                case nameof(Planet):
                    foreach (List<Planet> planets in PlanetsByStarName.Values)
                    {
                        result.AddRange(planets.ConvertAll(g => g.Name));
                    }
                    break;
                case nameof(Moon):
                    foreach (List<Moon> moons in MoonsByPlanetName.Values)
                    {
                        result.AddRange(moons.ConvertAll(g => g.Name));
                    }
                    break;
            }
            return result;
        }

        public string GetStatistics()
        {
            return Constants.Messages.STATS_START +
                Constants.Messages.STATS_GALAXIES + GalaxiesByName.Count + "\n" +
                Constants.Messages.STATS_STARS + PlanetsByStarName.Count + "\n" +
                Constants.Messages.STATS_PLANETS + MoonsByPlanetName.Count + "\n" +
                Constants.Messages.STATS_MOONS + ListSpaceUnitsByType(typeof(Moon)).Count + "\n" +
                Constants.Messages.STATS_END;
        }

        public string GetStatisticsByGalaxy(Galaxy galaxy)
        {
            /*
             public const string STATISTICS_STRUCTURE_BY_GALAXY = 
                "--- Data for {0} galaxy ---\n{1}\n"+ 
                STATS_STARS + "\n{2}\n" + 
                STATS_PLANETS + "\n{3}\n" + 
                STATS_MOONS + "\n{4}\n" + 
                "--- End of data for {0} galaxy ---";
             */

            StringBuilder sb = new StringBuilder();

            if (StarsByGalaxyName.ContainsKey(galaxy.Name))
            {
                foreach (Star star in StarsByGalaxyName[galaxy.Name])
                {
                    sb.Append(star.ToString() + "\n");
                    if (PlanetsByStarName.ContainsKey(star.Name))
                    {
                        sb.Append(Constants.Messages.STATS_PLANETS);
                        foreach (Planet planet in PlanetsByStarName[star.Name])
                        {
                            sb.Append(planet.ToString() + "\n");
                            if (MoonsByPlanetName.ContainsKey(planet.Name))
                            {
                                sb.Append(Constants.Messages.STATS_MOONS);
                                foreach (Moon moon in MoonsByPlanetName[planet.Name])
                                {
                                    sb.Append(moon.ToString() + "\n");
                                }
                            }
                        }
                    }
                }
            }
            return string.Format(Constants.Messages.STATISTICS_STRUCTURE_BY_GALAXY, galaxy.Name, galaxy.ToString(), sb.ToString());
        }


        private static void AddToMap<T,U>(Dictionary<string, List<T>> dictionary, Dictionary<string, U> originDictionary, string originName, T unit) where T : SpaceUnit
        {

            bool validOrigin = originDictionary.ContainsKey(originName) || Constants.Config.SKIP_ORIGIN_UNIT_VALIDATION;

            if (validOrigin)
            {

                if (!dictionary.ContainsKey(originName))
                {
                    dictionary[originName] = new List<T>();
                }
                dictionary[originName].Add(unit);

            } else
            {
                Console.WriteLine(String.Format(Constants.Messages.MISSING_ORIGIN, originName));
            }
        }

    }
}
