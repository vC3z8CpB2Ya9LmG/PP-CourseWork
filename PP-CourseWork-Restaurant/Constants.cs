
namespace PP_CourseWork_Restaurant
{
    public static class Constants
    {
        public const int RESTAURANT_TABLES_COUNT = 30;

        public static class ProductCategory
        {
            public const string SALAD = "Салата";
            public const string SOUP = "Супа";
            public const string MAIN_COURSE = "Основно ястие";
            public const string DESSERT = "Десерт";
            public const string DRINK = "Напитка";
        }
        public static class Functions
        {
            public const string SELLS = "продажби";
            public const string END = "изход";
        }

        public static class Messages
        {
            public const string TOTAL_TABLES_OCCUPIED = "Общо заети маси през деня: {0}";
            public const string TOTAL_SELLS = "Общо продажби: {0} – {1:F2}";
            public const string BY_CATEGORY_LABEL = "По категории:";
            public const string BY_CATEGORY_STATS = "-\t{0}: {1} – {2:F2}";
            public const string INVALID_INPUT = "Невалидни входни данни!";
        }

    }
}
