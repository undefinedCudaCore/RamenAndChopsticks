namespace RamenAndChopsticks.Models
{
    internal class Statictics : Receipt
    {
        public Statictics(string receiptId) : base(receiptId)
        {
            StatisticsId = receiptId;
        }
        public string StatisticsId { get; set; }
    }
}
