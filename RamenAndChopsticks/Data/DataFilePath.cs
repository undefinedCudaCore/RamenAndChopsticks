namespace RamenAndChopsticks.Data
{
    internal static class DataFilePath
    {
        private static readonly string oldPath = Environment.CurrentDirectory;
        private static readonly string newPath = Path.GetFullPath(Path.Combine(oldPath, @"..\..\..\"));

        internal static string DirectoryDataFiles = newPath + @"Data\DataFiles";
        internal static string DirectoryReceipts = newPath + @"Data\DataFiles\Receipts";

        internal static string DrinksInfoPath = newPath + @"Data\DataFiles\Drinks.json";
        internal static string FoodInfoPath = newPath + @"Data\DataFiles\Food.json";
        internal static string CustomersInfoPath = newPath + @"Data\DataFiles\Customers.json";
        internal static string EmployeesInfoPath = newPath + @"Data\DataFiles\Employees.json";
        internal static string OrdersInfoPath = newPath + @"Data\DataFiles\Orders.json";
        internal static string TableInfoPath = newPath + @"Data\DataFiles\Tables.json";
        internal static string ReceiptInfoPath = newPath + @"Data\DataFiles\Receipts\Receipt.json";
        internal static string StatisticsInfoPath = newPath + @"Data\DataFiles\Statistics.json";
    }
}
