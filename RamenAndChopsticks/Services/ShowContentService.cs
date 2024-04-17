using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class ShowContentService : IShowContent
    {
        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string color)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            switch (color.ToLower())
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }

            Console.WriteLine("Type the choise and press ENTER:");
            Console.WriteLine(optionOne);
            Console.WriteLine(optionTwo);
            Console.WriteLine(optionThree);
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
        }

        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string optionFour, string color)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            switch (color.ToLower())
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }

            Console.WriteLine("Type the choise and press ENTER:");
            Console.WriteLine(optionOne);
            Console.WriteLine(optionTwo);
            Console.WriteLine(optionThree);
            Console.WriteLine(optionFour);
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
        }

        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string optionFour, string optionFive, string color)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            switch (color.ToLower())
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
            }

            Console.WriteLine("Type the choise and press ENTER:");
            Console.WriteLine(optionOne);
            Console.WriteLine(optionTwo);
            Console.WriteLine(optionThree);
            Console.WriteLine(optionFour);
            Console.WriteLine(optionFive);
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
        }

        public void ShowGreating()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("- = Welcome to RAMEN AND CHOPSTICS = -");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
        }

        public void ShowReturnToMainMenu(string errorNumber)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine($"Error '{errorNumber}'. Read more Https://ramenandchopstics.co.jp/errors/{errorNumber} . You will be redirected to the main menu.");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
        public void ShowReturnToMainMenu(string username, string password)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");

            string star = "";

            for (int i = 0; i < password.Length; i++)
            {
                star += "*";
            }

            Console.WriteLine($"Wrong credentials: '{username}' or '{star}'.\nYou will be redirected to the main menu.");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        public void PrintTalbeList(Dictionary<string, Table> tableList)
        {
            //Dictionary<string, Table> tableList = Helpers.ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);
            string yes = "YES";
            string no = "NO";
            string noCustomer = "Here you will see the customers's name.";
            string noEmployee = "Here you will see the employee's name.";

            foreach (var table in tableList.Values)
            {
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine($"Table number: {table.TableNumber}.");
                Console.WriteLine($"Used by customer: {((String.IsNullOrEmpty(table.TableCurrentCustomer)) ? noCustomer : table.TableCurrentCustomer)}.");
                Console.WriteLine($"Served by employye: {((String.IsNullOrEmpty(table.TableCurrentEmployee)) ? noEmployee : table.TableCurrentEmployee)}.");
                Console.WriteLine($"Free spaces: {table.TableIableFreeSpacesLeft}.");
                Console.WriteLine($"Is table busy: {((table.TableIsBusy == true) ? yes : no)}.");
                Console.WriteLine($"Is table reserved: {((table.TableIsReserved == true) ? yes : no)}.");

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine();
            }
        }

        public void PrintItemList(Dictionary<string, Item> itemList)
        {
            foreach (var item in itemList.Values)
            {
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine($"Item ID: {item.ItemId}.");
                Console.WriteLine($"Item Name: {item.ItemName}.");
                Console.WriteLine($"Item Description: {item.ItemDescription}.");
                Console.WriteLine($"Item unit of measurement: {item.ItemUnitOfMeasurement}.");
                Console.WriteLine($"Item quantity: {item.ItemQty}.");
                Console.WriteLine($"Item price without VAT: {item.ItemPriceWithoutVat} €.");
                Console.WriteLine($"Item price with VAT: {item.ItemPriceWithVat} €.");

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine();
            }
        }

        public void PrintItemMenuList(Dictionary<string, Item> drinksList, Dictionary<string, Item> FoodList)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Restaurant MENU");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Drinks:");

            foreach (var drink in drinksList.Values)
            {
                Console.WriteLine($"ID: {drink.ItemId}.");
                Console.WriteLine($"Name: {drink.ItemName}.");
                Console.WriteLine($"Description: {drink.ItemDescription}.");
                Console.WriteLine($"Price with VAT: {drink.ItemPriceWithVat} €.");
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Food:");

            foreach (var food in FoodList.Values)
            {
                Console.WriteLine($"ID: {food.ItemId}.");
                Console.WriteLine($"Name: {food.ItemName}.");
                Console.WriteLine($"Description: {food.ItemDescription}.");
                Console.WriteLine($"Price with VAT: {food.ItemPriceWithVat} €.");
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
    }
}
