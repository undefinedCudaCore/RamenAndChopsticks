using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;


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
                    showContentService.ShowChooseOption(DataContent.EmployeeOptionData.OptionOne,
                        DataContent.EmployeeOptionData.OptionTwo,
                        DataContent.EmployeeOptionData.OptionThree, "green");

                    _chooseTableOrReservationOption = Console.ReadLine();
                    ChooseTableOrReservationStep(_chooseTableOrReservationOption.ToLower());
                    break;
                case "2":
                    _choices.Add(option);
                    Console.Clear();
                    showContentService.ShowGreating();
                    showContentService.ShowChooseOption(DataContent.CustomerOptionData.OptionOne,
                        DataContent.CustomerOptionData.OptionTwo,
                        DataContent.CustomerOptionData.OptionThree, "blue");

                    _chooseTableOrReservationOption = Console.ReadLine();
                    ChooseTableOrReservationStep(_chooseTableOrReservationOption.ToLower());
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
                try
                {
                    switch (option)
                    {
                        case "1":
                            Console.Clear();

                            Console.WriteLine("Register a new employee.");
                            break;
                        case "2":
                            Console.Clear();

                            Console.WriteLine("Choose a registered employee.");
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
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong; contact your system administrator...");
                }
                //Console.WriteLine("You are an employee; you cannot make table reservations or pass to the table during your working hours.");
                //Thread.Sleep(3);
                //Program.ChooseHuman();
            }
            if (_choices[0] == "2")
            {
                try
                {
                    switch (option)
                    {
                        case "1":
                            Console.Clear();

                            //Console.WriteLine("Pass to the table.");
                            Program.ChooseHuman();
                            break;
                        case "2":
                            Console.Clear();

                            //Console.WriteLine("Make table reservations.");
                            Program.ChooseHuman();
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

                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong; contact your system administrator...");
                }
            }
        }
    }
}
