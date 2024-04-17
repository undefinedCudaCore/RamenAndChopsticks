namespace RamenAndChopsticks.Models
{
    internal class Order
    {

        public Order(string orderTableId, int orderTableUsedSpaces, string orderDrinkId, double orderDrinkPriceWithVat,
            string orderFoodId, double orderFoodPriceWithVat, double orderTotalPrice, DateTime orderStartDateTime)
        {
            OrderTableId = orderTableId;
            OrderTableUsedSpaces = orderTableUsedSpaces;
            OrderDrinkId = orderDrinkId;
            OrderDrinkPriceWithVat = orderDrinkPriceWithVat;
            OrderFoodId = orderFoodId;
            OrderFoodPriceWithVat = orderFoodPriceWithVat;
            OrderTotalPrice = orderTotalPrice;
            OrderStartDateTime = orderStartDateTime;
        }

        public string OrderTableId { get; set; }
        public int OrderTableUsedSpaces { get; set; }
        public string OrderDrinkId { get; set; }
        public double OrderDrinkPriceWithVat { get; set; }
        public string OrderFoodId { get; set; }
        public double OrderFoodPriceWithVat { get; set; }
        public double OrderTotalPrice { get; set; }
        public DateTime OrderStartDateTime { get; set; }
        public DateTime OrderEndDateTime { get; set; }
    }
}
