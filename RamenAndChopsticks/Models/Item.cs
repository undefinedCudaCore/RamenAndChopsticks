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

        internal int ItemId { get; set; }
        internal double ItemQty { get; set; }
        internal double ItemPriceWithoutVat { get; set; }
        internal double ItemPriceWithVat { get; set; }
        internal string ItemName { get; set; }
        internal string ItemDescription { get; set; }
        internal string UnitOfMeasurement { get; set; }
    }
}
