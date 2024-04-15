using RamenAndChopsticks.Contracts;


namespace RamenAndChopsticks.Services
{
    internal class StepsService : ISteps
    {
        private string _chooseTableOrReservationOption;
        private List<string> _choices = new List<string>();

        public void ChooseHumanOptionStep(string option)
        {
            IShowContent showContentService = new ShowContentService();

            switch (option)
            {
                case "1":
                    _choices.Add(option);
                    Console.Clear();
                    showContentService.ShowGreating();

                    Console.WriteLine("Employee");

                    _chooseTableOrReservationOption = Console.ReadLine();
                    ChooseTableOrReservationStep(_chooseTableOrReservationOption);
                    break;
                case "2":
                    _choices.Add(option);
                    Console.Clear();
                    showContentService.ShowGreating();

                    Console.WriteLine("Human");

                    _chooseTableOrReservationOption = Console.ReadLine();
                    ChooseTableOrReservationStep(_chooseTableOrReservationOption);
                    break;
                case "q":
                    Console.Clear();

                    Program.Main();
                    break;
                default:
                    Thread.Sleep(3);
                    Console.Clear();

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

        public void ChooseTableOrReservationStep(string option)
        {
            IShowContent showContentService = new ShowContentService();
            showContentService.ShowGreating();

            if (_choices[0] == "1")
            {

                Console.WriteLine("You are an employee; you cannot make table reservations or pass to the table during your working hours.");
                Thread.Sleep(3);
                Program.ChooseHuman();
            }
            if (_choices[0] == "2")
            {
                switch (option)
                {
                    case "1":
                        Console.Clear();

                        Console.WriteLine("Pass to the table.");
                        break;
                    case "2":
                        Console.Clear();

                        Console.WriteLine("Make table reservations.");
                        break;
                    case "q":
                        Console.Clear();
                        Program.ChooseHuman();
                        break;
                    default:
                        Thread.Sleep(3);
                        Console.Clear();
                        Program.ChooseHuman();
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
}
