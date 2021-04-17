using System;

namespace PP_CourseWork_Parking
{
    class Vehicle
    {
        public VehicleType VehicleType { get;}
        public String Make { get; }
        public String Model { get; }

        public Vehicle(VehicleType type, String make, String model)
        {
            VehicleType = type;
            Make = make;
            Model = model;
        }

        public override string ToString()
        {
            return String.Format(Constants.Messages.VEHICLE_INFO, Make, Model);
        }
    }

}
