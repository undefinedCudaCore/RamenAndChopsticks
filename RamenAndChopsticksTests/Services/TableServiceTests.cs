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
            ITable tableService = new TableService();
            Dictionary<string, Table> testCreatedTablesCount = tableService.CreateTableListIfFileIsEmpty(60, 150);

            //Act
            Dictionary<string, Table> tablesList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);

            //Assert\
            Assert.That(tablesList.Values.Count, Is.EqualTo(testCreatedTablesCount.Values.Count));
        }

        [Test]
        public void GetTableTest()
        {
            //Arrange
            string testTableNumber = "1";
            string testTableCustomer = "Tadas Blinda";
            string testTableEmployee = "Andy";
            int testTableSpaces = 6;

            //Act
            ITable tableService = new TableService();
            File.Delete(DataFilePath.TableInfoPath);
            Dictionary<string, Table> testGetTableListOfTables = tableService.CreateTableListIfFileIsEmpty(5, 4);
            tableService.GetTable("1", "Tadas Blinda", "Andy", 4);

            //Assert\
            Assert.That(testGetTableListOfTables.Values.ToList()[0].TableNumber, Is.EqualTo(testTableNumber));
            Assert.That(testGetTableListOfTables.Values.ToList()[0].TableCurrentCustomer, Is.EqualTo(testTableCustomer));
            Assert.That(testGetTableListOfTables.Values.ToList()[0].TableCurrentEmployee, Is.EqualTo(testTableEmployee));
            Assert.That(testGetTableListOfTables.Values.ToList()[0].TableIableFreeSpacesLeft, Is.EqualTo(testTableSpaces));
        }

        [Test]
        public void ReserveTableTest()
        {
            //Arrange
            ITable tableService = new TableService();
            File.Delete(DataFilePath.TableInfoPath);
            Dictionary<string, Table> tablesList1 = tableService.CreateTableListIfFileIsEmpty(4, 10);
            tableService.ReserveTable("2", "Tadas2 Blinda2", "Andy2", 5);

            //Act
            Dictionary<string, Table> tablesList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);
            Table testTable = new Table("2", "Tadas2 Blinda2", "Andy2", 5, false, true);

            //Assert\
            Assert.That(tablesList, Contains.Value(testTable));
        }

        [Test]
        public void FreeUpTableTest()
        {
            //Arrange
            ITable tableService = new TableService();
            int spaces = 4;
            Dictionary<string, Table> testGetTableListOfTables = tableService.CreateTableListIfFileIsEmpty(5, spaces);
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