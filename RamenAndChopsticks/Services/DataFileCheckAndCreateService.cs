using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;

namespace RamenAndChopsticks.Services
{
    internal class DataFileCheckAndCreateService : IDataFile
    {
        public List<string> DataFileNames()
        {
            List<string> files = new List<string>();
            files.Add(DataFilePath.DrinksInfoPath);
            files.Add(DataFilePath.FoodInfoPath);
            files.Add(DataFilePath.CustomersInfoPath);
            files.Add(DataFilePath.OrderInfoPath);
            files.Add(DataFilePath.TableInfoPath);
            files.Add(DataFilePath.ReceiptInfoPath);
            files.Add(DataFilePath.StatisticsInfoPath);

            return files;
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
