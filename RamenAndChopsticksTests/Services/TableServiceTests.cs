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
            Dictionary<string, Table> testCreatedTablesCount = tableService.CreateTableListIfFileIsEmpty(60, 150);

            //Assert\
            Assert.That(tablesList.Values.Count, Is.EqualTo(testCreatedTablesCount.Values.Count));
        }

        [Test]
        public void GetTableTest()
        {
            //Arrange
            ITable tableService = new TableService();
            Dictionary<string, Table> testGetTableListOfTables = tableService.CreateTableListIfFileIsEmpty(5, 4);
            tableService.GetTable("1", "Tadas Blinda", "Andy", 4);

            //Act
            Dictionary<string, Table> tablesList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPathTest1);

            //Assert\
            Assert.That(testGetTableListOfTables, Is.EqualTo(tablesList));
        }

        [Test]
        public void ReserveTableTest()
        {

        }

        [Test]
        public void FreeUpTableTest()
        {
            //Arrange
            ITable tableService = new TableService();
            Dictionary<string, Table> testGetTableListOfTables = tableService.CreateTableListIfFileIsEmpty(5, 4);
            int spaces = 4;
            tableService.GetTable("1", "Tadas Blinda", "Andy", spaces);

            //Act
            tableService.FreeUpTable("1", out bool succ);
            Dictionary<string, Table> tablesList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPathTest2);

            //Assert\
            foreach (var testTable in tablesList)
            {
                var isBusy = testTable.Value.TableIsBusy;
                var isReserved = testTable.Value.TableIsReserved;
                var freeSpaces = testTable.Value.TableIableFreeSpacesLeft;
                var currentCustomer = testTable.Value.TableCurrentCustomer;
                var currentEmployee = testTable.Value.TableCurrentEmployee;

                Assert.That(isBusy, Is.EqualTo(false));
                Assert.That(isReserved, Is.EqualTo(false));
                Assert.That(freeSpaces, Is.EqualTo(spaces));
                Assert.That(currentCustomer, Is.EqualTo(""));
                Assert.That(currentEmployee, Is.EqualTo(""));
            }

            Assert.That(testGetTableListOfTables, Is.EqualTo(tablesList));
        }
    }
}