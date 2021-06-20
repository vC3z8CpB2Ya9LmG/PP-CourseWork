using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Galaxy
{
    class Planet : SpaceUnit
    {
        public PlanetType PlanetType { get; }
        public bool IsInhabited;

        //TODO: MOVE TO FACTORY
        public static Planet NewPlanet(string name, string type, bool isInhabited)
        {
            if (Enum.IsDefined(typeof(PlanetType),type))
            {
                return new Planet(name, (PlanetType)Enum.Parse(typeof(PlanetType),type), isInhabited);
            }
            Console.WriteLine(string.Format(Constants.Messages.INVALID_PLANET_TYPE, type));
            return null;
        }

        public override string Stats()
        {
            return string.Format(Constants.Messages.DETAILS_PLANET, Name, PlanetType, IsInhabited ? Constants.Messages.YES : Constants.Messages.NO);
        }

        Planet(string name, PlanetType type, bool isInhabited) : base(name)
        {
            PlanetType = type;
            IsInhabited = isInhabited;
        }
    }
}
