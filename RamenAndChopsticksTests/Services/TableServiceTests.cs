using NUnit.Framework;
using RamenAndChopsticks.Comparers;
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
        [SetUp]
        public void SetUp()
        {
            Dictionary<string, Table> tablesList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);

            tablesList["GCwqZKql"].TableCurrentCustomer = "";
            tablesList["GCwqZKql"].TableCurrentEmployee = "";
            tablesList["GCwqZKql"].TableIableFreeSpacesLeft = 4;
            tablesList["GCwqZKql"].TableIsBusy = false;

            tablesList["vPPT6PzS"].TableCurrentCustomer = "";
            tablesList["vPPT6PzS"].TableCurrentEmployee = "";
            tablesList["vPPT6PzS"].TableIableFreeSpacesLeft = 4;
            tablesList["vPPT6PzS"].TableIsReserved = false;

            WriteToFileHelper<Table>.WriteToFile(tablesList, DataFilePath.TableInfoPath);
        }

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
            int testTableSpaces = 0;

            //Act
            ITable tableService = new TableService();
            tableService.GetTable("1", "Tadas Blinda", "Andy", 4);
            Dictionary<string, Table> testGetTableListOfTables = Helpers.ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);

            //Assert
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
            IComparer<Table> tableComparer = new TableComparer();

            Table testTable = new Table("2", "Tadas2 Blinda2", "Andy2", 0, false, true);

            //Act
            Dictionary<string, Table> tablesList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);
            tableService.ReserveTable("2", "Tadas2 Blinda2", "Andy2", 4);

            //Assert 
            //must be Assert.That(mydict, Contains.Value(myOwnObject).Using(myComparer));
            Assert.That(tablesList, Contains.Value(testTable).Using(tableComparer));
        }

        [Test]
        public void FreeUpTableTest()
        {
            //Arrange
            ITable tableService = new TableService();
            int spaces = 4;
            tableService.GetTable("1", "Tadas Blinda", "Andy", spaces);
            Table testTable = new Table("1", "Tadas Blinda", "Andy", 0, true, false);
            Dictionary<string, Table> readFromFileTableList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);

            //Act
            tableService.FreeUpTable("1", out bool succ);
            Dictionary<string, Table> tablesList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPathTest2);

            //Assert

            Assert.That(readFromFileTableList, Does.Not.ContainValue(tablesList));
        }
    }
}