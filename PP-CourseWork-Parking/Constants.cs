
using System;

namespace PP_CourseWork_Parking
{
    public static class Constants
    {
        public static class VehicleType
        {
            public const string CAR = "Кола";
            public const string BUS = "Бус";
            public const string TRUCK = "Камион";
            public const string CAT_CAR = "Леки автомобили";
            public const string CAT_LIGHT_TRUCK = "Лекотоварни автомобили";
            public const string CAT_TRUCK = "Тежкотоварни автомобили";
        }
        public static class Functions
        {
            public const string PARKING = "Паркинг";
            public const string PRINT = "Печат";
            public const string END = "Край";
        }

        public static class Messages
        {
            public const string NO_PARKING = "Няма намерен паркинг с име {0}";
            public const string NO_VEHICLES = "Няма паркирани автомобили на паркинг {0}.";
            public const string PARKED_VEHICLES = "Паркирани автомобили в паркинг {0} :";
            public const string SUMMARY_HEADER = "Паркинг {0} разполага със следните места:\n";
            public const string PARKED_VEHICLE = "{0} {1}, заети {2}\n";
            public const string NO_FREE_PLACE = "Няма свободни паркоместа за {0} {1} {2}!";
            public const string INVALID_INPUT = "Невалидни входни данни!";
            public const string VEHICLE_INFO = "Марка {0}, модел {1}";
        }

    }
}
