using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PP_CourseWork_Galaxy
{
    class Program
    {
        
        static void Main()
        {
            SpaceMapLauncher();
        }

        static void SpaceMapLauncher()
        {

            SpaceMap spaceMap = SpaceMap.GetInstance();

            while (true)
            {
                String input = Console.ReadLine();
                if (input == null || input.Trim().Length == 0) continue;
                input = input.Trim();
                String[] elems = input.Split(" ");
                bool invalidInput = false;
                string content;

                switch (elems[0])
                {
                    case Constants.Functions.ADD:
                        string[] names = IOHelper.ExtractSpaceUnitNames(input);
                        string originName = names[0];
                        string unitName = elems[1].Equals(Constants.Functions.SPACE_UNIT.GALAXY) ? names[0] : names[1];
                        SpaceUnit spaceUnit = IOHelper.ReadSpaceUnitDetails(unitName, elems);
                        if(spaceUnit != null)
                        {
                            spaceMap.AddSpaceUnit(originName, spaceUnit);
                        }else
                        {
                            invalidInput = true;
                        }
                        break;
                    case Constants.Functions.PRINT:
                        string galaxyName = IOHelper.ExtractSpaceUnitNames(input.Substring(elems[0].Length))[0];
                        content = spaceMap.GetStatisticsByGalaxyName(galaxyName);
                        Console.WriteLine(string.Format(Constants.Messages.STATISTICS_STRUCTURE_BY_GALAXY,galaxyName,Constants.Functions.SPACE_UNIT.GALAXY,content));
                        break;
                    case Constants.Functions.LIST:
                        Type type = typeof(Galaxy);
                        content = Constants.Messages.NONE;
                        Console.WriteLine(string.Format(Constants.Messages.LIST_START, elems[1]));
                        switch (elems[1])
                        {
                            case Constants.Functions.SPACE_UNIT_PL.GALAXIES:
                                break;
                            case Constants.Functions.SPACE_UNIT_PL.STARS:
                                type = typeof(Star);
                                break;
                            case Constants.Functions.SPACE_UNIT_PL.PLANETS:
                                type = typeof(Planet);
                                break;
                            case Constants.Functions.SPACE_UNIT_PL.MOONS:
                                type = typeof(Moon);
                                break;
                            default: invalidInput = true; break;
                        }
                        if (!invalidInput) {
                            ICollection collection = spaceMap.ListSpaceUnitsByType(type);
                            if (collection.Count > 0)
                            {
                                StringBuilder sb = new StringBuilder();
                                foreach (var item in collection)
                                {
                                    sb.Append(item + "\n");
                                }
                                content = sb.ToString();
                            }
                        }
                        Console.WriteLine(content);
                        Console.WriteLine(string.Format(Constants.Messages.LIST_END,elems[1]));
                        break;
                    case Constants.Functions.STATS:
                        Console.WriteLine(spaceMap.GetStatistics());
                        break;
                    case Constants.Functions.EXIT:
                        return;

                }
            }
        }

            /* Planet planet = Planet.NewPlanet("koko", "mini_neptune", false);

             spaceMap.AddSpaceUnit("kokoko",planet);
             Galaxy gg = new Galaxy("Mlechen", GalaxyType.irregular, new Galaxy.GalaxyAge(23, "wwo"));

             Galaxy gg1 = new Galaxy("Zvezden", GalaxyType.elliptical, new Galaxy.GalaxyAge(25, "w22wo"));

             spaceMap.AddSpaceUnit("GG!", gg);
             spaceMap.AddSpaceUnit("PP!", gg1);

             Star star = new Star("star 01", 5778, 1f, 0.99f, 1f);
             Star star2 = new Star("star 02", 5778, 1f, 0.99f, 1f);
             *//*< mass > < size > < temp > < luminosity >*//*

             spaceMap.AddSpaceUnits(gg1.Name, star, star2);

             Planet p1 = Planet.NewPlanet("Planet01", PlanetType.giant_planet.ToString(), false);
             Planet p2 = Planet.NewPlanet("Planet02", PlanetType.ice_giant.ToString(), true);
             Planet p3 = Planet.NewPlanet("Planet03", PlanetType.mesoplanet.ToString(), false);
             Planet p4 = Planet.NewPlanet("Planet04", PlanetType.giant_planet.ToString(), true);
             Planet p5 = Planet.NewPlanet("Planet05", PlanetType.giant_planet.ToString(), true);



             spaceMap.AddSpaceUnit(star.Name, p1);
             spaceMap.AddSpaceUnit(star.Name, p5);
             spaceMap.AddSpaceUnit(star2.Name, p2);
             spaceMap.AddSpaceUnit(star2.Name, p3);
             spaceMap.AddSpaceUnit(star2.Name, p4);


             Console.WriteLine(spaceMap.ListSpaceUnitsByType(typeof (Galaxy)));

             Console.WriteLine("STATS" + spaceMap.GetStatistics());

             Console.WriteLine(spaceMap.GetStatisticsByGalaxy(gg1));*/

    }
}
