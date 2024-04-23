using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Helpers;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    public class TableService : ITable
    {
        internal Dictionary<string, Table> _tables = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);
        public static readonly int _maxTables = 20;
        internal static readonly int _tableSpaces = 4;

        public Dictionary<string, Table> CreateTableListIfFileIsEmpty(int tableQty, int tableSpaceQty)
        {
            if (_tables.Keys.Count != tableQty)
            {
                for (int i = 1; i <= tableQty; i++)
                {
                    _tables.Add(Helpers.RandomIdHelper.RandomIdGenerator(), new Table(i + "", "", "", tableSpaceQty, false, false));
                }
            }

            Helpers.WriteToFileHelper<Table>.WriteToFile(_tables, DataFilePath.TableInfoPath);

            return _tables;
        }

        public Dictionary<string, Table> GetTable(string tableId, string currentCustomer, string currentEmployee, int customerQty)
        {
            ISteps stepsService = new StepsService();
            IShowContent showContent = new ShowContentService();

            //Check if there are tables in the restaurant, if not - create one.
            CreateTableListIfFileIsEmpty(_maxTables, _tableSpaces);

            //Pass to the table
            foreach (var item in _tables)
            {
                if (item.Value.TableNumber == tableId && item.Value.TableIsBusy == true || item.Value.TableNumber == tableId && item.Value.TableIsReserved == true)
                {
                    Console.Clear();
                    showContent.ShowGreating();


                    //go to employees menu
                    showContent.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                        DataContent.EmployeeMenuData.OptionTwo,
                        DataContent.EmployeeMenuData.OptionThree,
                        DataContent.EmployeeMenuData.OptionFour,
                        DataContent.EmployeeMenuData.OptionSix,
                        DataContent.EmployeeMenuData.OptionFive, "green");

                    Console.WriteLine("Choose another table. The table is busy or reserved.");
                    stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), _tables);
                    break;
                }

                if (item.Value.TableNumber == tableId && item.Value.TableIsBusy == false || item.Value.TableNumber == tableId && item.Value.TableIsReserved == false)
                {
                    if (item.Value.TableIableFreeSpacesLeft < customerQty)
                    {
                        Console.Clear();
                        showContent.ShowGreating();

                        Console.WriteLine("Too many people split into a few groups and come back again.");

                        //go to employees menu
                        showContent.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                        DataContent.EmployeeMenuData.OptionTwo,
                        DataContent.EmployeeMenuData.OptionThree,
                        DataContent.EmployeeMenuData.OptionFour,
                        DataContent.EmployeeMenuData.OptionSix,
                        DataContent.EmployeeMenuData.OptionFive, "green");
                        stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), _tables);
                    }
                    item.Value.TableIsBusy = true;
                    item.Value.TableCurrentEmployee = currentEmployee;
                    item.Value.TableCurrentCustomer = currentCustomer;
                    item.Value.TableIableFreeSpacesLeft = item.Value.TableIableFreeSpacesLeft - customerQty;
                }
            }


            Helpers.WriteToFileHelper<Table>.WriteToFile(_tables, DataFilePath.TableInfoPath);

            return _tables;
        }

        public Dictionary<string, Table> ReserveTable(string tableId, string currentCustomer, string currentEmployee, int customerQty)
        {
            ISteps stepsService = new StepsService();
            IShowContent showContent = new ShowContentService();

            //Check if there are tables in the restaurant, if not - create one.
            CreateTableListIfFileIsEmpty(_maxTables, _tableSpaces);

            //Pass to the table
            foreach (var item in _tables)
            {
                if (item.Value.TableNumber == tableId && item.Value.TableIsBusy == true || item.Value.TableNumber == tableId && item.Value.TableIsReserved == true)
                {
                    Console.Clear();
                    showContent.ShowGreating();


                    //go to employees menu
                    showContent.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                        DataContent.EmployeeMenuData.OptionTwo,
                        DataContent.EmployeeMenuData.OptionThree,
                        DataContent.EmployeeMenuData.OptionFour,
                        DataContent.EmployeeMenuData.OptionSix,
                        DataContent.EmployeeMenuData.OptionFive, "green");

                    Console.WriteLine("Choose another table. The table is busy or reserved.");
                    stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), _tables);
                    break;
                }

                if (item.Value.TableNumber == tableId && item.Value.TableIsBusy == false || item.Value.TableNumber == tableId && item.Value.TableIsReserved == false)
                {
                    if (item.Value.TableIableFreeSpacesLeft < customerQty)
                    {
                        Console.Clear();
                        showContent.ShowGreating();

                        Console.WriteLine("Too many people split into a few groups and come back again.");

                        //go to employees menu
                        showContent.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                        DataContent.EmployeeMenuData.OptionTwo,
                        DataContent.EmployeeMenuData.OptionThree,
                        DataContent.EmployeeMenuData.OptionFour,
                        DataContent.EmployeeMenuData.OptionSix,
                        DataContent.EmployeeMenuData.OptionFive, "green");
                        stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), _tables);
                    }
                    item.Value.TableIsReserved = true;
                    item.Value.TableCurrentEmployee = currentEmployee;
                    item.Value.TableCurrentCustomer = currentCustomer;
                    item.Value.TableIableFreeSpacesLeft = item.Value.TableIableFreeSpacesLeft - customerQty;
                }
            }

            Helpers.WriteToFileHelper<Table>.WriteToFile(_tables, DataFilePath.TableInfoPath);

            return _tables;
        }

        public Dictionary<string, Table> FreeUpTable(string tableId, out bool successfullyFreedUp)
        {
            successfullyFreedUp = false;

            foreach (var item in _tables)
            {
                if (item.Value.TableNumber == tableId)
                {
                    item.Value.TableIsBusy = false;
                    item.Value.TableIsReserved = false;
                    item.Value.TableIableFreeSpacesLeft = _tableSpaces;
                    item.Value.TableCurrentCustomer = "";
                    item.Value.TableCurrentEmployee = "";

                    successfullyFreedUp = true;
                }
            }
            Helpers.WriteToFileHelper<Table>.WriteToFile(_tables, DataFilePath.TableInfoPath);

            return _tables;
        }
    }
}
