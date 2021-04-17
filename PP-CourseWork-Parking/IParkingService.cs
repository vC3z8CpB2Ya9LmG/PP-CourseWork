using System;

namespace PP_CourseWork_Parking
{
    interface IParkingService
    {
        public void CreateNewParking(string name, uint[] capacities);

        public void ParkVehicle(Vehicle vehicle);

        public void PrintVehicles(String parkingName);

        public void Finish();
    }
}
