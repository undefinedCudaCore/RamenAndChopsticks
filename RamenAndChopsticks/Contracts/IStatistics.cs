using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IStatistics
    {
        internal Dictionary<string, Receipt> WriteInTheFileReceipt(Receipt newReceipt);
    }
}
