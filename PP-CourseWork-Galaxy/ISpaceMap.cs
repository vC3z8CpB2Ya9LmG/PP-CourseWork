using System;
using System.Collections;

namespace PP_CourseWork_Galaxy
{
    interface ISpaceMap
    {
        public void AddSpaceUnit(String originName, SpaceUnit spaceUnit);
        public ICollection ListSpaceUnitsByType(Type spaceUnitType);
        public string GetStatistics();
        public string GetStatisticsByGalaxyName(string galaxyName);
    }
}
