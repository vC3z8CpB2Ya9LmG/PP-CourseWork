using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PP_CourseWork_Galaxy
{
    class IOHelper
    {
        internal static SpaceUnit ReadSpaceUnitDetails(string name, string[] elements)
        {
            int length = elements.Length;

            switch (elements[1])
            {
                case Constants.Functions.SPACE_UNIT.GALAXY:
                    GalaxyType galaxyType = (GalaxyType)Enum.Parse(typeof(GalaxyType), elements[length - 2]);
                    Galaxy.GalaxyAge galaxyAge = ParseGalaxyAge(elements[length - 1]);
                    return new Galaxy(name, galaxyType, galaxyAge);
                case Constants.Functions.SPACE_UNIT.STAR:
                    float mass = ParseFloatNumber(elements[length - 4]);
                    float size = ParseFloatNumber(elements[length - 3]);
                    int temperature = ParseIntNumber(elements[length - 2]);
                    float luminosity = ParseFloatNumber(elements[length - 1]);
                    return new Star(name, temperature, luminosity, mass, size);


                //                    StarClass(string name, int minTemperature, int maxTemperature, float minLuminosity, float maxLuminosity, float minMass, float maxMass, float minRadius, float maxRadius)
                //                      add star [Milky way] [Sun] 0.99 1.98 5778 1.00
                //                      add star [<galaxy name>] [<star name>] <mass> <size> <temp> <luminosity>

                case Constants.Functions.SPACE_UNIT.PLANET:
                    bool isInhabited = elements[length - 1].Equals(Constants.Messages.YES) ? true : false;
                    string type = elements[length - 2];
                    return Planet.NewPlanet(name, type, isInhabited);
                case Constants.Functions.SPACE_UNIT.MOON:
                    return new Moon(name);
                default: return null;
            }
        }

        internal static string[] ExtractSpaceUnitNames(string input)
        {
            MatchCollection matches = Regex.Matches(input, "(?<=\\[).+?(?=\\])");

            return matches.Count switch
            {
                1 => new string[] { matches[0].Value, string.Empty },
                2 => new string[] { matches[0].Value, matches[1].Value },
                _ => new string[] { string.Empty, string.Empty },
            };
        }

        internal static float ParseFloatNumber(string number)
        {
            try
            {
                return float.Parse(number);
            }
            catch (Exception)
            {
                return 0.0f;
            }
        }

        internal static int ParseIntNumber(string number)
        {
            try
            {
                return int.Parse(number);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        internal static Galaxy.GalaxyAge ParseGalaxyAge(string input)
        {
            try
            {
                return new Galaxy.GalaxyAge(ParseFloatNumber(input.Substring(0, input.Length-1)), input.Substring(input.Length-1));
            }
            catch (Exception)
            {
                return new Galaxy.GalaxyAge(0f, "ERROR");
            }
        }
    }
}
