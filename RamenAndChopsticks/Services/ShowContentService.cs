using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class ShowContentService : IShowContent
    {
        private readonly int _padding = 50;
        private bool PrintGreeting = true;
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
            string yes = "YES";
            string no = "NO";
            string noCustomer = "Here you will see the customers's name.";
            string noEmployee = "Here you will see the employee's name.";
            tableList = Helpers.ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);

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
            Console.OutputEncoding = System.Text.Encoding.Unicode;

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
                Console.WriteLine();
                Console.Write($"ID: {drink.ItemId}. ");
                Console.Write($"Name: {drink.ItemName}. ");
                Console.Write($"Description: {drink.ItemDescription}. ");
                Console.Write($"Price with VAT: {drink.ItemPriceWithVat} €. ");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Food:");

            foreach (var food in FoodList.Values)
            {
                Console.WriteLine();
                Console.Write($"ID: {food.ItemId}. ");
                Console.Write($"Name: {food.ItemName}. ");
                Console.Write($"Description: {food.ItemDescription}. ");
                Console.Write($"Price with VAT: {food.ItemPriceWithVat} €. ");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        public void PrintReceiptForCustomer(Receipt newReceipt)
        {
            PrintGreeting = false;

            Console.Clear();
            ShowGreating();

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("---==Customer receipt==---");
            Console.WriteLine("******************");
            Console.WriteLine(newReceipt.ReceiptRestorantName);
            Console.WriteLine(newReceipt.ReceiptAddress);

            Console.WriteLine(newReceipt.ReceiptDate.PadLeft(_padding));
            Console.WriteLine("******************");

            Console.WriteLine($"Table: {newReceipt.ReceiptTableId}   " +
                $"Order NO.: {newReceipt.ReceiptOrderId}   " +
                $"Guest: {newReceipt.ReceiptGuestName}");

            Console.WriteLine($"Drink: {newReceipt.ReceiptDrinkName} {newReceipt.ReceiptDrinkPriceWithVat} €".PadLeft(_padding));
            Console.WriteLine($"Meal: {newReceipt.ReceiptFoodName} {newReceipt.ReceiptFoodPriceWithVat} €".PadLeft(_padding));
            Console.WriteLine($"VAT: {newReceipt.ReceiptVatPercentage * 100} %".PadLeft(_padding));
            Console.WriteLine($"Total due: {newReceipt.ReceiptTotalDue} €".PadLeft(_padding));


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
        public void PrintReceiptForEmployee(Receipt newReceipt)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            if (PrintGreeting)
            {
                ShowGreating();
                PrintGreeting = true;
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("---==Employee receipt==---");
            Console.WriteLine("******************");
            Console.WriteLine(newReceipt.ReceiptRestorantName);
            Console.WriteLine(newReceipt.ReceiptAddress);

            Console.WriteLine(newReceipt.ReceiptDate.PadLeft(_padding));
            Console.WriteLine("******************");

            Console.WriteLine($"Table: {newReceipt.ReceiptTableId}   " +
                $"Order NO.: {newReceipt.ReceiptOrderId}   " +
                $"Guest: {newReceipt.ReceiptGuestName}");

            Console.WriteLine($"Employee username: {newReceipt.ReceiptEmployeeId}");
            Console.WriteLine($"Employee name: {newReceipt.ReceiptEmployeeName}");
            Console.WriteLine($"Employee job title: {newReceipt.ReceiptEmployeeJobTitle}");
            Console.WriteLine("******************");

            Console.WriteLine($"Drink ID: {newReceipt.ReceiptDrinkId}".PadLeft(_padding));
            Console.WriteLine($"Drink {newReceipt.ReceiptDrinkName}".PadLeft(_padding));
            Console.WriteLine($"Price without VAT: {newReceipt.ReceiptDrinkPriceWithoutVat} €");
            Console.WriteLine($"Price with VAT: {newReceipt.ReceiptDrinkPriceWithVat} €");
            Console.WriteLine("******************");
            Console.WriteLine($"Meal ID: {newReceipt.ReceiptFoodId}".PadLeft(_padding));
            Console.WriteLine($"Meal: {newReceipt.ReceiptFoodName}".PadLeft(_padding));
            Console.WriteLine($"Price without VAT: {newReceipt.ReceiptFoodPriceWithoutVat} €");
            Console.WriteLine($"Price with VAT: {newReceipt.ReceiptFoodPriceWithVat} €");
            Console.WriteLine("******************");
            Console.WriteLine($"VAT: {newReceipt.ReceiptVatPercentage * 100} %".PadLeft(_padding));
            Console.WriteLine($"Total due VAT sum: {newReceipt.ReceiptTotalVatSum} €".PadLeft(_padding));
            Console.WriteLine($"Total due with VAT: {newReceipt.ReceiptTotalDue} €".PadLeft(_padding));

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
    }
}
