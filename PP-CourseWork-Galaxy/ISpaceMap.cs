using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Galaxy
{
    interface ISpaceMap
    {
        public void AddSpaceUnit(String originName, SpaceUnit spaceUnit);
        public List<string> ListSpaceUnitsByType(Type spaceUnitType);
        public String GetStatistics();
    }
}
