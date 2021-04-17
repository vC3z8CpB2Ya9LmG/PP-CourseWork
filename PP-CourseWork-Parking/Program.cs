using System;

namespace PP_CourseWork_Parking
{
    class Program
    {

        public static void Main()
        {
            ParkingLauncher();
        }

        static void ParkingLauncher() {

            ParkingService parkingService = ParkingService.GetInstance();

            while (true)
            {
                String input = Console.ReadLine();
                if (input == null || input.Trim().Length == 0) continue;
                String[] elems = input.Trim().Split(" ");
                bool invalidInput = false;

                if (elems[0].Equals(Constants.Functions.PARKING) && elems.Length == 5)
                {
                    string parkingName = elems[1];
                    uint[] capacities = new uint[3];
                    try
                    {
                        capacities[0] = uint.Parse(elems[^3]);
                        capacities[1] = uint.Parse(elems[^2]);
                        capacities[2] = uint.Parse(elems[^1]);
                        parkingService.CreateNewParking(parkingName, capacities);
                    }
                    catch
                    {
                        invalidInput = true;
                    }
                }
                else if (elems[0].Equals(Constants.Functions.END) && elems.Length == 1)
                {
                    parkingService.Finish();
                    return;
                }
                else if (elems[0].Equals(Constants.Functions.PRINT) && elems.Length == 2)
                {
                    parkingService.PrintVehicles(elems[1]);
                }
                else
                {
                    VehicleType type = (VehicleType)elems[0];
                    if (type != null && elems.Length == 3)
                    {
                        parkingService.ParkVehicle(new Vehicle(type, elems[1], elems[2]));
                    }
                    else
                    {
                        invalidInput = true;
                    }
                }
                if (invalidInput)
                {
                    Console.WriteLine(Constants.Messages.INVALID_INPUT);
                }
            }
        }

    }
 
}
