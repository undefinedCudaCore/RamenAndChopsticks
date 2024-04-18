namespace RamenAndChopsticks.Models
{
    internal class Item
    {
        public Item(string itemId, string itemName, string itemCreationEmployeeId, string itemDescription, string unitOfMeasurement, double itemQty, double itemPriceWithoutVat)
        {
            ItemId = itemId;
            ItemName = itemName;
            ItemCreationEmployeeId = itemCreationEmployeeId;
            ItemQty = itemQty;
            ItemDescription = itemDescription;
            ItemUnitOfMeasurement = unitOfMeasurement;
            ItemPriceWithoutVat = Math.Round(itemPriceWithoutVat, 2);
            ItemPriceWithVat = Math.Round(itemPriceWithoutVat * 1.21, 2);
            ItemCreationDateTime = DateTime.Now.ToString("yyyy_MM_dd HH:mm:ss");
        }

        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCreationEmployeeId { get; set; }
        public double ItemQty { get; set; }
        public string ItemDescription { get; set; }
        public string ItemUnitOfMeasurement { get; set; }
        public double ItemPriceWithoutVat { get; set; }
        public double ItemPriceWithVat { get; set; }
        public string ItemCreationDateTime { get; set; }
    }
}
