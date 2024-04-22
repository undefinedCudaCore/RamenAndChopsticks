using NUnit.Framework;
using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using Assert = NUnit.Framework.Assert;

namespace RamenAndChopsticks.Services.Tests
{
    public class DataFileServiceTests
    {
        [Test]
        public void CheckFilesExistsTest()
        {
            //Arrange
            string filePath1 = DataFilePath.DrinksInfoPath;
            string filePath2 = DataFilePath.FoodInfoPath;
            string filePath3 = DataFilePath.EmployeesInfoPath;
            string filePath4 = DataFilePath.OrdersInfoPath;
            string filePath5 = DataFilePath.TableInfoPath;
            string filePath6 = DataFilePath.StatisticsInfoPath;

            //Act
            IDataFile fileService = new DataFileService();
            List<string> files = fileService.CheckFilesExists(fileService.DataFileNames());

            string filePathTest1 = files[0];
            string filePathTest2 = files[1];
            string filePathTest3 = files[2];
            string filePathTest4 = files[3];
            string filePathTest5 = files[4];
            string filePathTest6 = files[5];


            //Assert
            Assert.That(filePath1, Is.EqualTo(filePathTest1));
            Assert.That(filePath2, Is.EqualTo(filePathTest2));
            Assert.That(filePath3, Is.EqualTo(filePathTest3));
            Assert.That(filePath4, Is.EqualTo(filePathTest4));
            Assert.That(filePath5, Is.EqualTo(filePathTest5));
            Assert.That(filePath6, Is.EqualTo(filePathTest6));
        }

        [Test]
        public void CheckFilePathExistsTest()
        {
            //Arrange
            string directoryDataFilesPath = DataFilePath.DrinksInfoPath;
            string directoryReceiptsPath = DataFilePath.FoodInfoPath;

            //Act
            IDataFile fileService = new DataFileService();
            fileService.CreateDataFilePathAndFilesIfNotExists(fileService.DataFileNames());

            //Assert\
            Assert.That(File.Exists(directoryDataFilesPath));
            Assert.That(File.Exists(directoryReceiptsPath));
        }
    }
}