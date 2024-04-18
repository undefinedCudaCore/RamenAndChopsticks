namespace RamenAndChopsticks.Models
{
    internal class Table
    {
        public Table(string tableNumber, string tableCurrentCustomer, string tableCurrentEmployee, int tableITableSpaces, bool tableIsBusy, bool tableIsReserved)
        {
            TableNumber = tableNumber;
            TableCurrentCustomer = tableCurrentCustomer;
            TableCurrentEmployee = tableCurrentEmployee;
            TableIableFreeSpacesLeft = tableITableSpaces;
            TableIsBusy = tableIsBusy;
            TableIsReserved = tableIsReserved;
        }

        public string TableNumber { get; set; }
        public string TableCurrentCustomer { get; set; }
        public string TableCurrentEmployee { get; set; }
        public int TableIableFreeSpacesLeft { get; set; }
        public bool TableIsBusy { get; set; }
        public bool TableIsReserved { get; set; }
    }
}
