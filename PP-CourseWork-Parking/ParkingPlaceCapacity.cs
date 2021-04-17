
namespace PP_CourseWork_Parking
{
    class ParkingPlaceCapacity
    {
        public uint MaxCapacity { get; }
        public uint Capacity { get; set; }

        public ParkingPlaceCapacity(uint maxCapacity)
        {
            MaxCapacity = maxCapacity;
            Capacity = maxCapacity;
        }
    }
}
