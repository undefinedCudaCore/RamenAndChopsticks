namespace RamenAndChopsticks.Data
{
    public static class DataFilePath
    {
        public static readonly string oldPath = Environment.CurrentDirectory;
        public static readonly string newPath = Path.GetFullPath(Path.Combine(oldPath, @"..\..\..\"));

        public static string DirectoryDataFiles = newPath + @"Data\DataFiles";
        public static string DirectoryReceipts = newPath + @"Data\DataFiles\Receipts";

        public static string DrinksInfoPath = newPath + @"Data\DataFiles\Drinks.json";
        public static string FoodInfoPath = newPath + @"Data\DataFiles\Food.json";
        public static string CustomersInfoPath = newPath + @"Data\DataFiles\Customers.json";
        public static string EmployeesInfoPath = newPath + @"Data\DataFiles\Employees.json";
        public static string OrdersInfoPath = newPath + @"Data\DataFiles\Orders.json";
        public static string TableInfoPath = newPath + @"Data\DataFiles\Tables.json";
        public static string ReceiptInfoPath = newPath + @"Data\DataFiles\Receipts\Receipt.json";
        public static string StatisticsInfoPath = newPath + @"Data\DataFiles\Statistics.json";

        public static string TableInfoPathTest1 = newPath + @"Data\DataFiles\TablesTest1.json";
        public static string TableInfoPathTest2 = newPath + @"Data\DataFiles\TablesTest2.json";
    }
}
