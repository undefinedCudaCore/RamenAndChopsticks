using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface ITable
    {
        public Dictionary<string, Table> CreateTableListIfFileIsEmpty(int tableQty, int tableSpaceQty);
        public Dictionary<string, Table> GetTable(string tableId, string currentCustomer, string currentEmployee, int customerQty);
        public Dictionary<string, Table> ReserveTable(string tableId, string currentCustomer, string currentEmployee, int customerQty);
        public Dictionary<string, Table> FreeUpTable(string tableId, out bool successfullyFreedUp);
    }
}
