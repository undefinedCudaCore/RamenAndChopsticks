using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IOrder
    {
        internal Order CreateOrder(string orderDrinkId, string orderFoodId);
        internal Dictionary<string, Order> StartOrder(Order newOrder);
        internal Dictionary<string, Order> EndOrder(string orderId, string tableId);
    }
}
