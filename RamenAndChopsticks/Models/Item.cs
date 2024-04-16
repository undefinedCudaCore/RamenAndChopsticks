namespace RamenAndChopsticks.Models
{
    internal class Item
    {
        public Item(int itemId, double itemQty, double itemPriceWithoutVat, double itemPriceWithVat, string itemName, string itemDescription, string unitOfMeasurement)
        {
            ItemId = itemId;
            ItemQty = itemQty;
            ItemPriceWithoutVat = itemPriceWithoutVat;
            ItemPriceWithVat = itemPriceWithVat;
            ItemName = itemName;
            ItemDescription = itemDescription;
            UnitOfMeasurement = unitOfMeasurement;
        }

        public int ItemId { get; set; }
        public double ItemQty { get; set; }
        public double ItemPriceWithoutVat { get; set; }
        public double ItemPriceWithVat { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string UnitOfMeasurement { get; set; }
    }
}
