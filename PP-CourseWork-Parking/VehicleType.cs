using System;
using System.Collections.Generic;

namespace PP_CourseWork_Parking
{
    class VehicleType
    {
        public static readonly VehicleType CAR = new VehicleType(0, Constants.VehicleType.CAR, Constants.VehicleType.CAT_CAR);
        public static readonly VehicleType LIGHT_TRUCK = new VehicleType(1, Constants.VehicleType.BUS, Constants.VehicleType.CAT_LIGHT_TRUCK);
        public static readonly VehicleType TRUCK = new VehicleType(2, Constants.VehicleType.TRUCK, Constants.VehicleType.CAT_TRUCK);

        public static implicit operator int(VehicleType vt) => vt.Index;
        public static implicit operator string(VehicleType vt) => vt.Label;

        public static explicit operator VehicleType(int idx)
        {
            switch (idx)
            {
                case 0:
                    return CAR;
                case 1:
                    return LIGHT_TRUCK;
                case 2:
                    return TRUCK;
                default:
                    break;
            }
            return null;
        }

        public static explicit operator VehicleType(string name)
        {
            switch (name)
            {
                case Constants.VehicleType.CAR:
                    return CAR;
                case Constants.VehicleType.BUS:
                    return LIGHT_TRUCK;
                case Constants.VehicleType.TRUCK:
                    return TRUCK;
                default:
                    break;
            }
            return null;
        }

        public static IEnumerable<VehicleType> Values
        {
            get
            {
                yield return CAR;
                yield return LIGHT_TRUCK;
                yield return TRUCK;
            }
        }

        public int Index { get; }
        public String Label { get; }

        public String LabelPL { get; }

        private VehicleType(int index, String label, String labelPL)
        {
            Index = index;
            Label = label;
            LabelPL = labelPL;
        }
    }
}
