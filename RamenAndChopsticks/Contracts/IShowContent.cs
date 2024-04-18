using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IShowContent
    {
        public void ShowGreating();
        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string color);
        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string optionFour, string color);
        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string optionFour, string optionFive, string color);
        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string optionFour, string optionFive, string optionSix, string color);
        public void ShowReturnToMainMenu(string errorNumber);
        public void ShowReturnToMainMenu(string username, string password);
        internal void PrintTalbeList(Dictionary<string, Table> tableList);
        internal void PrintItemList(Dictionary<string, Item> itemList);
        internal void PrintItemMenuList(Dictionary<string, Item> drinksList, Dictionary<string, Item> FoodList);
        internal void PrintReceiptForCustomer(Receipt newReceipt);
        internal void PrintReceiptForEmployee(Receipt newReceipt);
        public void RedirectMessage(string message);

        internal void PrintStatistics();
    }
}
