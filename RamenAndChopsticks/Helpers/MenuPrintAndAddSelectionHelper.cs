using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Models;
using RamenAndChopsticks.Services;

namespace RamenAndChopsticks.Helpers
{
    internal static class MenuPrintAndAddSelectionHelper
    {
        internal static void MenuPrintAndAddSelection(out string selectedDrink, out string selectedFood)
        {
            Dictionary<string, Item> DrinksList = Helpers.ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.DrinksInfoPath);
            Dictionary<string, Item> FoodList = Helpers.ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.FoodInfoPath);
            IShowContent showContent = new ShowContentService();

            showContent.PrintItemMenuList(DrinksList, FoodList);

            Console.WriteLine();

            Console.WriteLine("Please select one drink. Type drink ID and press ENTER: ");
            selectedDrink = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Please select one meal. Type meals ID and press ENTER: ");
            selectedFood = Console.ReadLine();

            Console.WriteLine();
        }
    }
}
