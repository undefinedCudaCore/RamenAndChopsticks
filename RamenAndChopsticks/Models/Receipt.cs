namespace RamenAndChopsticks.Models
{
    internal class Receipt
    {
        public Receipt(string receiptId)
        {
            ReceiptId = receiptId;
        }

        public string ReceiptId { get; set; }
        public string ReceiptRestorantName { get; set; }
        public string ReceiptAddress { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptTableId { get; set; }
        public int ReceiptTableSpacesUsed { get; set; }
        public string ReceiptOrderId { get; set; }
        public string ReceiptGuestName { get; set; }
        public string ReceiptEmployeeId { get; set; }
        public string ReceiptEmployeeJobTitle { get; set; }
        public string ReceiptEmployeeName { get; set; }
        public string ReceiptDrinkId { get; set; }
        public string ReceiptDrinkName { get; set; }
        public double ReceiptDrinkPriceWithoutVat { get; set; }
        public double ReceiptDrinkPriceWithVat { get; set; }
        public string ReceiptFoodId { get; set; }
        public string ReceiptFoodName { get; set; }
        public double ReceiptFoodPriceWithoutVat { get; set; }
        public double ReceiptFoodPriceWithVat { get; set; }
        public double ReceiptVatPercentage { get; set; }
        public double ReceiptTotalVatSum { get; set; }
        public double ReceiptTotalDue { get; set; }
    }
}
