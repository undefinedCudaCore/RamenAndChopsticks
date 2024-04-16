using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
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

        public void PrintTalbeList()
        {
            Dictionary<string, Table> tableList = Helpers.ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);
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
    }
}
