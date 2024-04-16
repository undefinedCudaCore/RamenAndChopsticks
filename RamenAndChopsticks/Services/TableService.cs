using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Helpers;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class TableService : ITable
    {
        private Dictionary<string, Table> _tables = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);
        private readonly int _tableSpaces = 4;
        private readonly int _maxTables = 20;

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
                if (item.Value.TableNumber == tableId && item.Value.TableIsBusy == false && item.Value.TableIsReserved == false)
                {
                    if (item.Value.TableIableFreeSpacesLeft < customerQty)
                    {
                        Console.Clear();
                        showContent.ShowGreating();

                        Console.WriteLine("Too many people split into a few groups and come back again.");

                        //go to employees menu
                        showContent.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                            DataContent.EmployeeMenuData.OptionTwo, DataContent.EmployeeMenuData.OptionThree, DataContent.EmployeeMenuData.OptionFour, "green");
                        stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine());
                        break;
                    }
                    item.Value.TableIsBusy = true;
                    item.Value.TableCurrentEmployee = currentEmployee;
                    item.Value.TableCurrentCustomer = currentCustomer;
                    item.Value.TableIableFreeSpacesLeft = item.Value.TableIableFreeSpacesLeft - customerQty;
                }
                else
                {
                    Console.Clear();
                    showContent.ShowGreating();

                    Console.WriteLine("Choose another table. The table is busy or reserved.");

                    //go to employees menu
                    showContent.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                        DataContent.EmployeeMenuData.OptionTwo, DataContent.EmployeeMenuData.OptionThree, DataContent.EmployeeMenuData.OptionFour, "green");
                    stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine());
                    break;
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
                if (item.Value.TableNumber == tableId && item.Value.TableIsBusy == false && item.Value.TableIsReserved == false)
                {
                    if (item.Value.TableIableFreeSpacesLeft < customerQty)
                    {
                        Console.Clear();
                        showContent.ShowGreating();

                        Console.WriteLine("Too many people split into a few groups and come back again.");

                        //go to employees menu
                        showContent.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                            DataContent.EmployeeMenuData.OptionTwo, DataContent.EmployeeMenuData.OptionThree, DataContent.EmployeeMenuData.OptionFour, "green");
                        stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine());
                        break;
                    }
                    item.Value.TableIsReserved = true;
                    item.Value.TableCurrentEmployee = currentEmployee;
                    item.Value.TableCurrentCustomer = currentCustomer;
                    item.Value.TableIableFreeSpacesLeft = item.Value.TableIableFreeSpacesLeft - customerQty;
                }
                else
                {
                    Console.Clear();
                    showContent.ShowGreating();

                    Console.WriteLine("Choose another table. The table is busy or reserved.");

                    //go to employees menu
                    showContent.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                        DataContent.EmployeeMenuData.OptionTwo, DataContent.EmployeeMenuData.OptionThree, DataContent.EmployeeMenuData.OptionFour, "green");
                    stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine());
                    break;
                }
            }

            Helpers.WriteToFileHelper<Table>.WriteToFile(_tables, DataFilePath.TableInfoPath);

            return _tables;
        }

        public Dictionary<string, Table> FreeUpTable(string tableId)
        {
            foreach (var item in _tables)
            {
                if (item.Value.TableNumber == tableId)
                {
                    item.Value.TableIsBusy = false;
                    item.Value.TableIsReserved = false;
                    item.Value.TableIableFreeSpacesLeft = _tableSpaces;
                    item.Value.TableCurrentCustomer = "";
                    item.Value.TableCurrentEmployee = "";
                }
            }

            Helpers.WriteToFileHelper<Table>.WriteToFile(_tables, DataFilePath.TableInfoPath);

            return _tables;
        }

    }
}
