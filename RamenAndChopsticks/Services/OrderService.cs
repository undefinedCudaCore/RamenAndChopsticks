using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Helpers;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class OrderService : IOrder
    {
        private Dictionary<string, Order> OrdersList = ReadFromFileHelper<Order>.ReadFromFile(DataFilePath.OrdersInfoPath);
        private Dictionary<string, Table> TablesList = ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);
        private Dictionary<string, Item> DrinksList = ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.DrinksInfoPath);
        private Dictionary<string, Item> FoodList = ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.FoodInfoPath);

        public Dictionary<string, Order> StartOrder(Order newOrder)
        {
            try
            {
                OrdersList.Add(RandomIdHelper.RandomIdGenerator(), newOrder);

                WriteToFileHelper<Order>.WriteToFile(OrdersList, DataFilePath.OrdersInfoPath);

                return OrdersList;

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(DataContent.ErrorsAndExceptionsData.NullReferenceException);
            }
            catch (FormatException)
            {
                throw new FormatException(DataContent.ErrorsAndExceptionsData.FormatException);
            }
            catch (Exception)
            {
                throw new Exception(DataContent.ErrorsAndExceptionsData.Exception);
            }
        }

        public Dictionary<string, Order> EndOrder(string orderId, string tableId)
        {
            ITable tableService = new TableService();

            foreach (var order in OrdersList.Where(kvp => kvp.Value.OrderId == orderId).ToList())
            {
                order.Value.OrderEndDateTime = DateTime.Now;
            }

            tableService.FreeUpTable(tableId, out bool successfullyFreedUp);

            WriteToFileHelper<Order>.WriteToFile(OrdersList, DataFilePath.OrdersInfoPath);

            return OrdersList;
        }

        public Order CreateOrder(string orderDrinkId, string orderFoodId)
        {
            string orderId = RandomIdHelper.RandomIdGenerator();
            string orderTableId = StepsService._currentTable;
            string orderPersonnelWhoServedId = StepsService._currentUser;
            int orderTableUsedSpaces = 0;
            double orderDrinkPriceWithVat = 0;
            double orderFoodPriceWithVat = 0;
            double orderTotalPrice = 0;
            DateTime orderStartDateTime = DateTime.Now;

            foreach (var table in TablesList.Values)
            {
                if (table.TableNumber == orderTableId)
                {
                    orderTableUsedSpaces = table.TableIableFreeSpacesLeft;
                }
            }

            foreach (var drink in DrinksList.Values)
            {
                if (drink.ItemId == orderDrinkId)
                {
                    orderDrinkPriceWithVat = drink.ItemPriceWithVat;
                }
            }

            foreach (var food in FoodList.Values)
            {
                if (food.ItemId == orderDrinkId)
                {
                    orderFoodPriceWithVat = food.ItemPriceWithVat;
                }
            }

            orderTotalPrice = orderDrinkPriceWithVat + orderFoodPriceWithVat;

            Order newOrder = new Order(orderId, orderTableId, orderPersonnelWhoServedId, orderTableUsedSpaces, orderDrinkId, orderDrinkPriceWithVat, orderFoodId,
                orderFoodPriceWithVat, orderTotalPrice, orderStartDateTime);

            return newOrder;
        }
    }
}
