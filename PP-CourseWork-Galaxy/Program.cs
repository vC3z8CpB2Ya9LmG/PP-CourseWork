using System;

namespace PP_CourseWork_Galaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            SpaceMap spaceMap = SpaceMap.GetInstance();
            Planet planet = Planet.NewPlanet("koko", "mini_neptune", false);

            spaceMap.AddSpaceUnit("kokoko",planet);
            Galaxy gg = new Galaxy("Mlechen", GalaxyType.irregular, new Galaxy.GalaxyAge(23, "wwo"));

            Galaxy gg1 = new Galaxy("Zvezden", GalaxyType.elliptical, new Galaxy.GalaxyAge(25, "w22wo"));

            spaceMap.AddSpaceUnit("GG!", gg);
            spaceMap.AddSpaceUnit("PP!", gg1);

            Star star = new Star("star 01", 5778, 1f, 0.99f, 1f);
            Star star2 = new Star("star 02", 5778, 1f, 0.99f, 1f);
            /*< mass > < size > < temp > < luminosity >*/

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

            Console.WriteLine(spaceMap.GetStatisticsByGalaxy(gg1));

        }
    }
}
