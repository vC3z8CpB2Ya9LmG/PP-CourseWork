using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PP_CourseWork_Parking
{
    class ParkingService : IParkingService 
    {
        private readonly Dictionary<string, Parking> parkings;

        private static readonly ParkingService instance = new ParkingService();

        public static ParkingService GetInstance() { return instance; }

        private ParkingService() { parkings = new Dictionary<string, Parking>(); }

        public void CreateNewParking(string name, uint[] capacities)
        {
            parkings.Add(name, new Parking(name, capacities));
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            foreach (var parking in parkings.Values)
            {
                if (parking.ParkVehicle(vehicle))
                {
                    return;
                }
            }
            Console.WriteLine(String.Format(Constants.Messages.NO_FREE_PLACE, vehicle.VehicleType.Label.ToLower(), vehicle.Make, vehicle.Model));
        }

        public void PrintVehicles(string parkingName)
        {
            Func<Parking, string> formattedCarsListing = parking =>
            {
                if (parking.Vehicles.Count == 0)
                {
                    return String.Format(Constants.Messages.NO_VEHICLES, parking.Name);
                }
                StringBuilder sb = new StringBuilder(String.Format(Constants.Messages.PARKED_VEHICLES, parking.Name));

                foreach (var vehicle in parking.Vehicles)
                {
                    sb.Append("\n" + vehicle.ToString());
                }
                return sb.ToString();
            };

            if (parkings.ContainsKey(parkingName))
            {
                Console.WriteLine(formattedCarsListing(parkings[parkingName]));
            }
            else
            {
                Console.WriteLine(String.Format(Constants.Messages.NO_PARKING, parkingName));
            }
        }

        public void Finish()
        {
            Func<Parking, string> formattedSummary = parking =>
            {
                StringBuilder sb = new StringBuilder(String.Format(Constants.Messages.SUMMARY_HEADER, parking.Name));
                for (int i = 0; i < VehicleType.Values.Count(); i++)
                {
                    sb.Append(String.Format(Constants.Messages.PARKED_VEHICLE, ((VehicleType)i).LabelPL, parking.Capacity[i].MaxCapacity, parking.Capacity[i].MaxCapacity - parking.Capacity[i].Capacity));
                }
                return sb.ToString();
            };

            foreach (Parking parking in parkings.Values)
            {
                Console.WriteLine(formattedSummary(parking));
            }
        }

    }
}
