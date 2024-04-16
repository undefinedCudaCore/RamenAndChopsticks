using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Helpers;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class TableService : ITable
    {
        private Dictionary<string, Table> _tables = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);

        public Dictionary<string, Table> CreateTableListIfFileIsEmpty(int tableQty, int tableSpaceQty)
        {
            Dictionary<string, Table> result = new Dictionary<string, Table>();

            if (_tables.Values.Count != tableQty)
            {
                for (int i = 1; i <= tableQty; i++)
                {
                    result.Add(Helpers.RandomIdHelper.RandomIdGenerator(), new Table(i + "", "", tableSpaceQty, false, false));
                }
            }

            Helpers.WriteToFileHelper<Table>.WriteToFile(result, DataFilePath.TableInfoPath);

            return result;
        }

        public Dictionary<string, Table> GetTable(string tableId, string currentCustomer, string currentEmployee)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Table> ReserveTable(string tableId, string currentCustomer, string currentEmployee)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Table> FreeUpTable(string tableId)
        {
            throw new NotImplementedException();
        }

    }
}
