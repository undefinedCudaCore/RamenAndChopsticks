using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Helpers;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class ReceiptService : IReceipt
    {
        public Receipt CreateReceipt(string receiptId)
        {
            string restorantName = "Ramen and CHOPSTICKS";
            string restourantAddress = "62 Thomas Street, New York, NY";
            string receiptDate = DateTime.Now.ToString("dddd_dd_MMMM_yyyy_HH_mm_ss");
            string receiptTableId = StepsService._currentTable;
            string receiptOrderId = StepsService._currentOrder;
            string receiptGuestName = "";
            int receiptTableSpacesUsed = 0;
            string receiptEmployeeId = StepsService._currentUser;
            string receiptEmployeeJobTitle = "";
            string receiptEmployeeName = "";
            string receiptDrinkId = "";
            string receiptDrinkName = "";
            double receiptDrinkPriceWithoutVat = Double.NaN;
            double receiptDrinkPriceWithVat = Double.NaN;
            string receiptFoodId = "";
            string receiptFoodName = "";
            double receiptFoodPriceWithoutVat = Double.NaN;
            double receiptFoodPriceWithVat = Double.NaN;
            double receiptVatPercentage = 0.21;
            double receiptTotalVatSum = Double.NaN;
            double receiptTotalDue = Double.NaN;

            Dictionary<string, Order> OrdersList = ReadFromFileHelper<Order>.ReadFromFile(DataFilePath.OrdersInfoPath);
            Dictionary<string, Item> DrinksList = ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.DrinksInfoPath);
            Dictionary<string, Item> FoodList = ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.FoodInfoPath);
            Dictionary<string, Employee> EmployeeList = ReadFromFileHelper<Employee>.ReadFromFile(DataFilePath.EmployeesInfoPath);
            Dictionary<string, Table> TableList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);

            foreach (var table in TableList.Values)
            {
                if (table.TableNumber == receiptTableId)
                {
                    receiptGuestName = table.TableCurrentCustomer;
                    receiptTableSpacesUsed = table.TableIableFreeSpacesLeft;
                }
            }

            foreach (var employee in EmployeeList.Values)
            {
                if (employee.EmployeeUsername == receiptEmployeeId)
                {
                    receiptEmployeeJobTitle = employee.EmployeeJobTitle;
                    receiptEmployeeName = employee.EmployeeName + " " + employee.EmployeeSurename;
                }
            }

            foreach (var order in OrdersList.Values)
            {
                if (order.OrderId == receiptOrderId)
                {
                    receiptDrinkId = order.OrderDrinkId;
                    receiptDrinkPriceWithVat = order.OrderDrinkPriceWithVat;

                    receiptFoodId = order.OrderFoodId;
                    receiptFoodPriceWithVat = order.OrderFoodPriceWithVat;

                    receiptTotalDue = order.OrderTotalPrice;
                    receiptTotalVatSum = receiptTotalDue / (1 + receiptVatPercentage);
                }
            }
            receiptDrinkPriceWithoutVat = receiptDrinkPriceWithVat / (1 + receiptVatPercentage);
            receiptFoodPriceWithoutVat = receiptFoodPriceWithVat / (1 + receiptVatPercentage);

            foreach (var drink in DrinksList.Values)
            {
                if (drink.ItemId == receiptDrinkId)
                {
                    receiptDrinkName = drink.ItemName;
                }
            }

            foreach (var food in FoodList.Values)
            {
                if (food.ItemId == receiptFoodId)
                {
                    receiptFoodName = food.ItemName;
                }
            }

            Receipt newReceipt = new Receipt(Helpers.RandomIdHelper.RandomIdGenerator());

            newReceipt.ReceiptRestorantName = restorantName;
            newReceipt.ReceiptAddress = restourantAddress;
            newReceipt.ReceiptDate = receiptDate;
            newReceipt.ReceiptTableId = receiptTableId;
            newReceipt.ReceiptOrderId = receiptOrderId;
            newReceipt.ReceiptGuestName = receiptGuestName;
            newReceipt.ReceiptTableSpacesUsed = receiptTableSpacesUsed;
            newReceipt.ReceiptEmployeeId = receiptEmployeeId;
            newReceipt.ReceiptEmployeeJobTitle = receiptEmployeeJobTitle;
            newReceipt.ReceiptEmployeeName = receiptEmployeeName;
            newReceipt.ReceiptDrinkId = receiptDrinkId;
            newReceipt.ReceiptDrinkName = receiptDrinkName;
            newReceipt.ReceiptDrinkPriceWithoutVat = Math.Round(receiptDrinkPriceWithoutVat, 2);
            newReceipt.ReceiptDrinkPriceWithVat = Math.Round(receiptDrinkPriceWithVat, 2);
            newReceipt.ReceiptFoodId = receiptFoodId;
            newReceipt.ReceiptFoodName = receiptFoodName;
            newReceipt.ReceiptFoodPriceWithoutVat = Math.Round(receiptFoodPriceWithoutVat, 2);
            newReceipt.ReceiptFoodPriceWithVat = Math.Round(receiptFoodPriceWithVat, 2);
            newReceipt.ReceiptVatPercentage = Math.Round(receiptVatPercentage, 2);
            newReceipt.ReceiptTotalVatSum = Math.Round(receiptTotalVatSum, 2);
            newReceipt.ReceiptTotalDue = Math.Round(receiptTotalDue, 2);

            return newReceipt;
        }

        public Dictionary<string, Receipt> WriteInTheFileReceipt(Receipt newReceipt)
        {
            Dictionary<string, Receipt> newReceiptList = new Dictionary<string, Receipt>();
            string receiptFile = DataFilePath.DirectoryReceipts + @"\Receipt_" + newReceipt.ReceiptId + "_" + newReceipt.ReceiptDate + ".json";
            try
            {
                if (!File.Exists(receiptFile))
                {
                    File.Create(receiptFile).Close();
                }

                newReceiptList.Add(RandomIdHelper.RandomIdGenerator(), newReceipt);

                WriteToFileHelper<Receipt>.WriteToFile(newReceiptList, receiptFile);

                return newReceiptList;

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(DataContent.ErrorsAndExceptionsData.NullReferenceException);
            }
            catch (FormatException)
            {
                throw new FormatException(DataContent.ErrorsAndExceptionsData.FormatException);
            }
            catch (Exception)
            {
                throw new Exception(DataContent.ErrorsAndExceptionsData.Exception);
            }
        }
    }
}
