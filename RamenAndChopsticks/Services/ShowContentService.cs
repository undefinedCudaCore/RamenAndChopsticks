using RamenAndChopsticks.Contracts;

namespace RamenAndChopsticks.Services
{
    internal class ShowContentService : IShowContent
    {
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
    }
}
