using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface ITable
    {
        internal Dictionary<string, Table> CreateTableListIfFileIsEmpty(int tableQty, int tableSpaceQty);
        internal Dictionary<string, Table> GetTable(string tableId, string currentCustomer, string currentEmployee, int customerQty);
        internal Dictionary<string, Table> ReserveTable(string tableId, string currentCustomer, string currentEmployee, int customerQty);
        internal Dictionary<string, Table> FreeUpTable(string tableId);
    }
}
