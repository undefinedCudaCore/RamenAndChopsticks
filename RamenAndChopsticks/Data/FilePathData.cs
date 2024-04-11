namespace RamenAndChopsticks.Data
{
    internal static class FilePathData
    {
        private static readonly string oldPath = Environment.CurrentDirectory;
        private static readonly string newPath = Path.GetFullPath(Path.Combine(oldPath, @"..\..\..\"));

        internal static string DrinksInfoPath = newPath + @"Data\Drinks.json";
        internal static string FoodInfoPath = newPath + @"Data\Food.json";
        internal static string CustomersInfoPath = newPath + @"Data\Customers.json";
        internal static string OrderInfoPath = newPath + @"Data\Orders.json";
        internal static string TableInfoPath = newPath + @"Data\Orders.json";
        internal static string ReceiptInfoPath = newPath + @"Data\Receipt.json";
        internal static string StatisticsInfoPath = newPath + @"Data\Statistics.json";
    }
}
