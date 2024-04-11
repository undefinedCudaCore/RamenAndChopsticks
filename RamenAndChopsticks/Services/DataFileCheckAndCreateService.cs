using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;

namespace RamenAndChopsticks.Services
{
    internal class DataFileCheckAndCreateService : IDataFile
    {
        public List<string> DataFileNames()
        {
            List<string> files = new List<string>();
            files.Add(FilePathData.DrinksInfoPath);
            files.Add(FilePathData.FoodInfoPath);
            files.Add(FilePathData.CustomersInfoPath);
            files.Add(FilePathData.OrderInfoPath);
            files.Add(FilePathData.TableInfoPath);
            files.Add(FilePathData.ReceiptInfoPath);
            files.Add(FilePathData.StatisticsInfoPath);

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

        public bool DataFilesCreated(List<string> dataFileList)
        {

            try
            {
                foreach (var file in dataFileList)
                {
                    File.Create(file);

                    return true;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
