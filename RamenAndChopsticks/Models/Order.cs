namespace RamenAndChopsticks.Models
{
    internal class Order
    {
        public Order(string orderId, string orderTableId, string orderPersonnelWhoServedId, int orderTableUsedSpaces, string orderDrinkId,
            double orderDrinkPriceWithVat, string orderFoodId, double orderFoodPriceWithVat,
            double orderTotalPrice, DateTime orderStartDateTime)
        {
            OrderId = orderId;
            OrderTableId = orderTableId;
            OrderPersonnelWhoServedId = orderPersonnelWhoServedId;
            OrderTableUsedSpaces = orderTableUsedSpaces;
            OrderDrinkId = orderDrinkId;
            OrderDrinkPriceWithVat = orderDrinkPriceWithVat;
            OrderFoodId = orderFoodId;
            OrderFoodPriceWithVat = orderFoodPriceWithVat;
            OrderTotalPrice = orderTotalPrice;
            OrderStartDateTime = orderStartDateTime;
        }

        public string OrderId { get; set; }
        public string OrderTableId { get; set; }
        public string OrderPersonnelWhoServedId { get; set; }
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
