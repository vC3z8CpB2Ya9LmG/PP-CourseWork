using System;
using System.Collections.Generic;
using System.Linq;

namespace PP_CourseWork_Parking
{
    class Parking
    {
        public String Name { get; }

        public ParkingPlaceCapacity[] Capacity;

        public List<Vehicle> Vehicles { get; }

        public Parking(string name, uint[] capacities)
        {
            Name = name;
            Vehicles = new List<Vehicle>();
            InitCapacity(capacities);
        }

        private void InitCapacity(uint[] capacities)
        {
            Capacity = new ParkingPlaceCapacity[VehicleType.Values.Count()];

            for (int i = 0; i < Capacity.Length; i++)
            {
                Capacity[i] = new ParkingPlaceCapacity(capacities[i]);
            }
        }

        public uint GetAvailabilityFor(VehicleType vehicleType)
        {
            return Capacity[vehicleType].Capacity;
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            if (Capacity[(int)vehicle.VehicleType].Capacity > 0) {
                Vehicles.Add(vehicle);
                Capacity[vehicle.VehicleType].Capacity--;
                return true;
            }
            return false;
        }

    }
}