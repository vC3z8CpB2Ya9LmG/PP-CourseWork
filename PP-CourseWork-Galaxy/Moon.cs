using System;
using System.Collections.Generic;
using System.Text;

namespace PP_CourseWork_Galaxy
{
    class Moon : SpaceUnit
    {

        public Moon(string name) : base(name)
        { }

        public override string Stats()
        {
            return string.Format(Constants.Messages.DETAILS_MOON, Name);
        }
    }
}
