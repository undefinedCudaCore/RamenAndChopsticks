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
    }
}
