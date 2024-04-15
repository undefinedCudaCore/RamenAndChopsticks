using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class DataFileService : IDataFile
    {
        public List<string> DataFileNames()
        {
            DataFile dataFile = new DataFile();

            dataFile.Files.Add(DataFilePath.DrinksInfoPath);
            dataFile.Files.Add(DataFilePath.FoodInfoPath);
            dataFile.Files.Add(DataFilePath.CustomersInfoPath);
            dataFile.Files.Add(DataFilePath.EmployeesInfoPath);
            dataFile.Files.Add(DataFilePath.OrderInfoPath);
            dataFile.Files.Add(DataFilePath.TableInfoPath);
            dataFile.Files.Add(DataFilePath.ReceiptInfoPath);
            dataFile.Files.Add(DataFilePath.StatisticsInfoPath);

            return dataFile.Files;
        }

        public List<string> CheckFilesExists(List<string> dataFileList)
        {
            try
            {
                List<string> checkFilesExistByGivenFilePath = new List<string>();

                foreach (var file in dataFileList)
                {
                    if (!File.Exists(file))
                    {
                        checkFilesExistByGivenFilePath.Add(file);
                    }
                }
                return checkFilesExistByGivenFilePath;

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("A null list is given.. (DataFileCheckAndCreateService.CheckFilesExists)");
            }
            catch (Exception)
            {
                throw new Exception("Another huge problem, contact the system administrator.. (DataFileCheckAndCreateService.CheckFilesExists)");
            }
        }

        public void DataFilesCreated(List<string> dataFileList)
        {
            try
            {
                foreach (var file in dataFileList)
                {
                    File.Create(file).Close();
                }
                return;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
