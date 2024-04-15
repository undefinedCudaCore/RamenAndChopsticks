using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Models;


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

                    Environment.Exit(0);
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
            IEmployee employeeService = new EmployeeService();
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
                            showContentService.ShowGreating();

                            Console.WriteLine("Enter username: ");
                            string username = Console.ReadLine();

                            Console.WriteLine("Enter password: ");
                            string password = Console.ReadLine();

                            Console.WriteLine("Enter name: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("Enter surname: ");
                            string surname = Console.ReadLine();

                            Console.WriteLine("Enter age: ");
                            bool bAge = int.TryParse(Console.ReadLine(), out int age);

                            if (!bAge)
                            {
                                Console.WriteLine("Enter the wrong age, try one more time. If you enter the age incorrectly, the employee's age will be saved as \"0\".");
                                bAge = int.TryParse(Console.ReadLine(), out age);
                            }

                            Console.WriteLine("Enter gender: ");
                            string gender = Console.ReadLine();

                            Console.WriteLine("Enter job title: ");
                            string jobTitle = Console.ReadLine();

                            employeeService.AddEmployee(new Employee(username, password, name, surname, age, gender, jobTitle));
                            //DO SOMETHING (main employee menu)
                            break;
                        case "2":
                            Console.Clear();
                            showContentService.ShowGreating();

                            Console.WriteLine("Enter username: ");
                            username = Console.ReadLine();

                            Console.WriteLine("Enter password: ");
                            password = Console.ReadLine();

                            bool successfullyLoggedIn = employeeService.LoginEmployee(username, password);

                            //DO SOMETHING (main employee menu)
                            if (successfullyLoggedIn)
                            {
                                Console.WriteLine("LOGGEDIN");
                                //go to employees menu
                            }
                            else
                            {
                                showContentService.ShowReturnToMainMenu(username, password);
                                Thread.Sleep(3000);
                                Console.Clear();

                                Program.ChooseHuman();
                            }
                            //Console.WriteLine("Choose a registered employee.");
                            break;
                        case "q":
                            Console.Clear();
                            showContentService.ShowGreating();

                            Program.ChooseHuman();
                            break;
                        default:
                            Thread.Sleep(3);
                            Console.Clear();
                            showContentService.ShowGreating();

                            Program.ChooseHuman();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong; contact your system administrator...");
                }
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
