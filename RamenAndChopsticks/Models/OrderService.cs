using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Services;

namespace RamenAndChopsticks.Models
{
    internal class OrderService : IOrder
    {
        private Dictionary<string, Order> OrdersList = Helpers.ReadFromFileHelper<Order>.ReadFromFile(Data.DataFilePath.OrdersInfoPath);

        public Dictionary<string, Order> StartOrder(Order newOrder)
        {
            try
            {
                OrdersList.Add(Helpers.RandomIdHelper.RandomIdGenerator(), newOrder);

                Helpers.WriteToFileHelper<Order>.WriteToFile(OrdersList, Data.DataFilePath.OrdersInfoPath);

                return OrdersList;

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(Data.DataContent.ErrorsAndExceptionsData.NullReferenceException);
            }
            catch (FormatException)
            {
                throw new FormatException(Data.DataContent.ErrorsAndExceptionsData.FormatException);
            }
            catch (Exception)
            {
                throw new Exception(Data.DataContent.ErrorsAndExceptionsData.Exception);
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

            Helpers.WriteToFileHelper<Order>.WriteToFile(OrdersList, Data.DataFilePath.OrdersInfoPath);

            return OrdersList;
        }
    }
}
