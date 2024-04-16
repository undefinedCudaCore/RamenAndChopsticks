namespace RamenAndChopsticks.Models
{
    internal class Table
    {
        public Table(string tableNumber, string tableCurrentCustomer, int tableITableSpaces, bool tableIsBusy, bool tableIsReserved)
        {
            TableNumber = tableNumber;
            TableCurrentCustomer = tableCurrentCustomer;
            TableITableSpaces = tableITableSpaces;
            TableIsBusy = tableIsBusy;
            TableIsReserved = tableIsReserved;
        }

        public string TableNumber { get; set; }
        public string TableCurrentCustomer { get; set; }
        public int TableITableSpaces { get; set; }
        public bool TableIsBusy { get; set; }
        public bool TableIsReserved { get; set; }
    }
}
