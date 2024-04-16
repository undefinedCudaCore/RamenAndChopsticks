using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Models;


namespace RamenAndChopsticks.Services
{
    internal class StepsService : ISteps
    {
        private string _chooseOption;
        private List<string> _choices = new List<string>();
        internal static string _currentUser;

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

                    _chooseOption = Console.ReadLine();
                    ChooseEmployeeCreationOrLoginStep(_chooseOption.ToLower());
                    break;
                case "2":
                    _choices.Add(option);
                    Console.Clear();
                    showContentService.ShowGreating();
                    showContentService.ShowChooseOption(DataContent.CustomerOptionData.OptionOne,
                        DataContent.CustomerOptionData.OptionTwo,
                        DataContent.CustomerOptionData.OptionThree, "blue");

                    _chooseOption = Console.ReadLine();
                    ChooseEmployeeCreationOrLoginStep(_chooseOption.ToLower());
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
                Console.WriteLine(DataContent.ErrorsAndExceptions.ExceptionSomethingWrong);
            }
        }

        public void ChooseEmployeeCreationOrLoginStep(string option)
        {
            IEmployee employeeService = new EmployeeService();
            IShowContent showContentService = new ShowContentService();
            showContentService.ShowGreating();

            bool successfullyLoggedIn;

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
                            successfullyLoggedIn = employeeService.LoginEmployee(username, password);

                            if (successfullyLoggedIn)
                            {
                                _currentUser = username;
                                Console.Clear();
                                //go to employees menu
                                showContentService.ShowGreating();
                                showContentService.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                                    DataContent.EmployeeMenuData.OptionTwo, DataContent.EmployeeMenuData.OptionThree, DataContent.EmployeeMenuData.OptionFour, DataContent.EmployeeMenuData.OptionFive, "green");
                                ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine());
                            }
                            else
                            {
                                showContentService.ShowReturnToMainMenu(username, password);
                                Thread.Sleep(3000);
                                Console.Clear();

                                Program.ChooseHuman();
                            }
                            break;
                        case "2":
                            Console.Clear();
                            showContentService.ShowGreating();

                            Console.WriteLine("Enter username: ");
                            username = Console.ReadLine();

                            Console.WriteLine("Enter password: ");
                            password = Console.ReadLine();

                            successfullyLoggedIn = employeeService.LoginEmployee(username, password);

                            //DO SOMETHING (main employee menu)
                            if (successfullyLoggedIn)
                            {
                                _currentUser = username;
                                Console.Clear();
                                //go to employees menu
                                showContentService.ShowGreating();
                                showContentService.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                                    DataContent.EmployeeMenuData.OptionTwo, DataContent.EmployeeMenuData.OptionThree,
                                    DataContent.EmployeeMenuData.OptionFour, DataContent.EmployeeMenuData.OptionFive, "green");
                                ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine());
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
                    Console.WriteLine(DataContent.ErrorsAndExceptions.ExceptionSomethingWrong);
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
                    Console.WriteLine(DataContent.ErrorsAndExceptions.ExceptionSomethingWrong);
                }
            }
        }

        public void ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(string option)
        {
            IShowContent showContentService = new ShowContentService();
            ITable tableServise = new TableService();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    showContentService.ShowGreating();
                    showContentService.PrintTalbeList();

                    Console.WriteLine("Type the table number and press ENTER:");
                    string tableNumber = Console.ReadLine();

                    Console.WriteLine("Type the customer's name and press ENTER:");
                    string customerName = Console.ReadLine();

                    Console.WriteLine("Type the customer quantity and press ENTER:");
                    bool bCustomeQty = int.TryParse(Console.ReadLine(), out int customerQty);

                    if (!bCustomeQty)
                    {
                        Console.WriteLine("Enter the wrong age, try one more time. If you enter the age incorrectly, the employee's age will be saved as \"0\".");
                        bCustomeQty = int.TryParse(Console.ReadLine(), out customerQty);
                    }

                    tableServise.GetTable(tableNumber, customerName, _currentUser, customerQty);
                    break;
                case "2":
                    Console.Clear();
                    showContentService.ShowGreating();

                    Console.WriteLine("Type the table number and press ENTER:");
                    tableNumber = Console.ReadLine();

                    Console.WriteLine("Type the customer's name and press ENTER:");
                    customerName = Console.ReadLine();

                    Console.WriteLine("Type the customer quantity and press ENTER:");
                    bCustomeQty = int.TryParse(Console.ReadLine(), out customerQty);

                    if (!bCustomeQty)
                    {
                        Console.WriteLine("Enter the wrong age, try one more time. If you enter the age incorrectly, the employee's age will be saved as \"0\".");
                        bCustomeQty = int.TryParse(Console.ReadLine(), out customerQty);
                    }

                    tableServise.ReserveTable(tableNumber, customerName, _currentUser, customerQty);
                    break;
                case "3":
                    Console.Clear();
                    showContentService.ShowGreating();

                    Console.WriteLine("Type the table number to free up the table and press ENTER:");
                    tableNumber = Console.ReadLine();

                    tableServise.FreeUpTable(tableNumber, out bool successfullyFreedUp);

                    if (successfullyFreedUp)
                    {
                        Console.WriteLine("The table is free now.");
                        Thread.Sleep(3000);

                        Console.Clear();
                        showContentService.ShowGreating();
                        showContentService.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                            DataContent.EmployeeMenuData.OptionTwo, DataContent.EmployeeMenuData.OptionThree,
                            DataContent.EmployeeMenuData.OptionFour, DataContent.EmployeeMenuData.OptionFive, "green");
                        ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine());
                    }

                    if (!successfullyFreedUp)
                    {
                        Console.WriteLine("The table is free now.");
                        Thread.Sleep(3000);

                        Console.Clear();
                        showContentService.ShowGreating();
                        showContentService.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                            DataContent.EmployeeMenuData.OptionTwo, DataContent.EmployeeMenuData.OptionThree,
                            DataContent.EmployeeMenuData.OptionFour, DataContent.EmployeeMenuData.OptionFive, "green");
                        ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine());
                    }
                    break;
                case "4":
                    Console.Clear();
                    showContentService.ShowGreating();
                    //Add food or drink

                    break;
                case "q":
                    Console.Clear();
                    showContentService.ShowGreating();
                    showContentService.ShowChooseOption(DataContent.EmployeeOptionData.OptionOne,
                        DataContent.EmployeeOptionData.OptionTwo,
                        DataContent.EmployeeOptionData.OptionThree, "green");
                    ChooseEmployeeCreationOrLoginStep(Console.ReadLine());
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
                Console.WriteLine(DataContent.ErrorsAndExceptions.ExceptionSomethingWrong);
            }

        }
    }
}
