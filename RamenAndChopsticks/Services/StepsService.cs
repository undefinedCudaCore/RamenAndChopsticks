using RamenAndChopsticks.Contracts;


namespace RamenAndChopsticks.Services
{
    internal class StepsService : ISteps
    {
        public void ChooseHumanOptionStep(string option)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Employee");
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Human");
                    break;
                case "q":
                    Console.Clear();
                    Console.WriteLine("go back");
                    Program.Main();
                    break;
                default:
                    Thread.Sleep(1);
                    Console.Clear();
                    Console.WriteLine("go back 2");
                    Program.Main();
                    break;
            }
            try
            {

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong; contact your system administrator...");
            }
        }
    }
}
