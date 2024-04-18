using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IStatistics
    {
        internal Dictionary<string, Receipt> WriteInTheFileReceipt(Receipt newReceipt);
        public List<double> GetProfitOfTheDay();
        public List<int> GetTablesWereUntakesNumber();
        internal List<Item> GetProductsAddedToday();
    }
}
