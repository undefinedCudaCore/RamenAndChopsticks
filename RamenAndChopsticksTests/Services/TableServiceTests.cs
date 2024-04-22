using NUnit.Framework;
using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Helpers;
using RamenAndChopsticks.Models;
using Assert = NUnit.Framework.Assert;

namespace RamenAndChopsticks.Services.Tests
{
    [TestFixture()]
    public class TableServiceTests
    {
        [Test]
        public void CreateTableListIfFileIsEmptyTest()
        {
            //Arrange
            Dictionary<string, Table> tablesList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);

            //Act
            ITable tableService = new TableService();
            Dictionary<string, Table> testCreatedTablesAndSpaces = tableService.CreateTableListIfFileIsEmpty(60, 150);

            //Assert\
            Assert.That(tablesList.Values.Count, Is.EqualTo(testCreatedTablesAndSpaces.Values.Count));
        }

        [Test]
        public void GetTableTest()
        {
            Assert.Fail();
        }

        [Test]
        public void ReserveTableTest()
        {
            Assert.Fail();
        }

        [Test]
        public void FreeUpTableTest()
        {
            Assert.Fail();
        }
    }
}