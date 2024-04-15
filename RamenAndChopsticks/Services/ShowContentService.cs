using RamenAndChopsticks.Contracts;

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

            Console.WriteLine($"Error '{errorNumber}'. Read more Https://ramenandchopstics.co.jp/errors/{errorNumber} . You will be redirected to main menu.");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
    }
}
