using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IReceipt
    {
        internal Receipt CreateReceipt(string receiptId);
        internal Dictionary<string, Receipt> WriteInTheFileReceipt(Receipt newReceipt);
    }
}
