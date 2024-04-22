using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Helpers;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class StatisticsService : IStatistics
    {
        public Dictionary<string, Receipt> WriteInTheFileReceipt(Receipt newReceipt)
        {
            Dictionary<string, Receipt> statisticsList = Helpers.ReadFromFileHelper<Receipt>.ReadFromFile(DataFilePath.StatisticsInfoPath);

            try
            {
                statisticsList.Add(RandomIdHelper.RandomIdGenerator(), newReceipt);

                WriteToFileHelper<Receipt>.WriteToFile(statisticsList, DataFilePath.StatisticsInfoPath);

                return statisticsList;

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

        public List<double> GetProfitOfTheDay()
        {
            double totalProfitOfTheDayWithVat = 0;
            double totalProfitOfTheDayWithouthVat = 0;
            string todayDate = DateTime.Now.ToString("yyyy_MM_dd");
            List<double> profitOfTheDay = new List<double>();
            string receiptDataForCheck = "";

            Dictionary<string, Receipt> receiptList = Helpers.ReadFromFileHelper<Receipt>.ReadFromFile(DataFilePath.StatisticsInfoPath);
            foreach (var receipt in receiptList.Values)
            {
                receiptDataForCheck = receipt.ReceiptDate.Substring(0, 10);
                if (receiptDataForCheck == todayDate)
                {
                    totalProfitOfTheDayWithVat += receipt.ReceiptTotalDue;
                    totalProfitOfTheDayWithouthVat += receipt.ReceiptTotalDue / (1 + receipt.ReceiptVatPercentage);
                }
            }

            profitOfTheDay.Add(Math.Round(totalProfitOfTheDayWithouthVat, 2));
            profitOfTheDay.Add(Math.Round(totalProfitOfTheDayWithVat, 2));

            return profitOfTheDay;
        }

        public List<int> GetTablesWereUntakesNumber()
        {
            int howOftenTablesWereUntaken = 0;
            int freeSpacesOfAllOrderedTables = 0;
            List<int> tableSpaceInfo = new List<int>();

            Dictionary<string, Receipt> receiptList = Helpers.ReadFromFileHelper<Receipt>.ReadFromFile(DataFilePath.StatisticsInfoPath);

            foreach (var receipt in receiptList.Values)
            {
                if (receipt.ReceiptTableSpacesUsed != 0)
                {
                    howOftenTablesWereUntaken++;
                    freeSpacesOfAllOrderedTables += receipt.ReceiptTableSpacesUsed;
                }
            }

            tableSpaceInfo.Add(howOftenTablesWereUntaken);
            tableSpaceInfo.Add(freeSpacesOfAllOrderedTables);

            return tableSpaceInfo;
        }

        public List<Item> GetProductsAddedToday()
        {
            string todayDate = DateTime.Now.ToString("yyyy_MM_dd");
            List<Item> productsAddedToday = new List<Item>();

            Dictionary<string, Item> drinksList = Helpers.ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.DrinksInfoPath);
            Dictionary<string, Item> mealList = Helpers.ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.FoodInfoPath);

            foreach (var drink in drinksList.Values)
            {
                if (drink.ItemCreationDateTime.Substring(0, 10) == todayDate)
                {
                    productsAddedToday.Add(drink);
                }
            }

            foreach (var meal in mealList.Values)
            {
                if (meal.ItemCreationDateTime.Substring(0, 10) == todayDate)
                {
                    productsAddedToday.Add(meal);
                }
            }

            return productsAddedToday;
        }
    }
}
