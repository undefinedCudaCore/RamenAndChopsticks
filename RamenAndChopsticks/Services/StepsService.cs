using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Models;
using RamenAndChopsticks.Redirectors;


namespace RamenAndChopsticks.Services
{
    internal class StepsService : ISteps
    {
        private string _chooseOption;
        internal static List<string> _choices = new List<string>();
        internal static string _currentUser;
        internal static string _currentTable;
        internal static string _currentOrder;
        private Dictionary<string, Table> TabelList = Helpers.ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);
        private Dictionary<string, Item> DrinksList = Helpers.ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.DrinksInfoPath);
        private Dictionary<string, Item> FoodList = Helpers.ReadFromFileHelper<Item>.ReadFromFile(DataFilePath.FoodInfoPath);

        public void ChooseHumanOptionStep(string option)
        {
            IShowContent showContentService = new ShowContentService();

            try
            {
                switch (option)
                {
                    case "1":
                        CaseEmployee(option, showContentService);
                        break;
                    case "2":
                        CaseCustomer(option, showContentService);
                        break;
                    case "q":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        showContentService.RedirectMessage(DataContent.RedirectorsData.WrongInputOperationFailedRedirectMainPage);
                        Thread.Sleep(3000);
                        Console.Clear();
                        Redirect.RedirectTo("MainMenu");
                        break;
                }

            }
            catch (Exception)
            {
                Console.WriteLine(DataContent.ErrorsAndExceptionsData.ExceptionSomethingWrong);
            }
        }

        private void CaseCustomer(string option, IShowContent showContentService)
        {
            _choices.Add(option);
            Console.Clear();
            showContentService.ShowGreating();
            showContentService.ShowChooseOption(DataContent.CustomerOptionData.OptionOne,
                DataContent.CustomerOptionData.OptionTwo,
                DataContent.CustomerOptionData.OptionThree, "blue");

            _chooseOption = Console.ReadLine();
            ChooseEmployeeCreationOrLoginStep(_chooseOption.ToLower());
        }

        private void CaseEmployee(string option, IShowContent showContentService)
        {
            _choices.Add(option);
            Console.Clear();
            showContentService.ShowGreating();
            showContentService.ShowChooseOption(DataContent.EmployeeOptionData.OptionOne,
                DataContent.EmployeeOptionData.OptionTwo,
                DataContent.EmployeeOptionData.OptionThree, "green");

            _chooseOption = Console.ReadLine();
            ChooseEmployeeCreationOrLoginStep(_chooseOption.ToLower());
        }

        public void ChooseEmployeeCreationOrLoginStep(string option)
        {
            Dictionary<string, Table> tableList = Helpers.ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);
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
                            string username, password;
                            CaseRegisterNewEmployee(tableList, employeeService, showContentService, out successfullyLoggedIn, out username, out password);
                            break;
                        case "2":
                            CaseEmployeeLogin(tableList, employeeService, showContentService, out successfullyLoggedIn, out username, out password);
                            break;
                        case "q":
                            Console.Clear();

                            Redirect.RedirectTo("MainMenu");
                            break;
                        default:
                            Console.Clear();
                            showContentService.ShowGreating();
                            showContentService.RedirectMessage(DataContent.RedirectorsData.WrongInputOperationFailedRedirectMainPage);
                            Thread.Sleep(3000);
                            Console.Clear();

                            Redirect.RedirectTo("MainMenu");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(DataContent.ErrorsAndExceptionsData.ExceptionSomethingWrong);
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

                            Redirect.RedirectTo("MainMenu");
                            break;
                        case "2":
                            Console.Clear();

                            Redirect.RedirectTo("MainMenu");
                            break;
                        case "q":
                            Console.Clear();
                            Redirect.RedirectTo("MainMenu");
                            break;
                        default:
                            Console.Clear();
                            showContentService.ShowGreating();
                            showContentService.RedirectMessage(DataContent.RedirectorsData.WrongInputOperationFailedRedirectMainPage);
                            Thread.Sleep(3000);
                            Console.Clear();

                            Redirect.RedirectTo("MainMenu");
                            break;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine(DataContent.ErrorsAndExceptionsData.ExceptionSomethingWrong);
                }
            }
        }

        private void CaseEmployeeLogin(Dictionary<string, Table> tableList, IEmployee employeeService, IShowContent showContentService, out bool successfullyLoggedIn, out string username, out string password)
        {
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
                    DataContent.EmployeeMenuData.OptionTwo,
                    DataContent.EmployeeMenuData.OptionThree,
                    DataContent.EmployeeMenuData.OptionFour,
                    DataContent.EmployeeMenuData.OptionSix,
                    DataContent.EmployeeMenuData.OptionFive, "green");
                ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), tableList);
            }
            else
            {
                showContentService.ShowReturnToMainMenu(username, password);
                Thread.Sleep(3000);
                Console.Clear();

                Redirect.RedirectTo("MainMenu");
            }
        }

        private void CaseRegisterNewEmployee(Dictionary<string, Table> tableList, IEmployee employeeService, IShowContent showContentService, out bool successfullyLoggedIn, out string username, out string password)
        {
            Console.Clear();
            showContentService.ShowGreating();

            Console.WriteLine("Enter username: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            password = Console.ReadLine();
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
                    DataContent.EmployeeMenuData.OptionTwo,
                    DataContent.EmployeeMenuData.OptionThree,
                    DataContent.EmployeeMenuData.OptionFour,
                    DataContent.EmployeeMenuData.OptionSix,
                    DataContent.EmployeeMenuData.OptionFive, "green");
                ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), tableList);
            }
            else
            {
                showContentService.ShowReturnToMainMenu(username, password);
                Thread.Sleep(3000);
                Console.Clear();

                Redirect.RedirectTo("MainMenu");
            }
        }

        public void ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(string option, Dictionary<string, Table> tabels)
        {
            IShowContent showContentService = new ShowContentService();
            ITable tableService = new TableService();
            IOrder orderService = new OrderService();
            IReceipt receiptService = new ReceiptService();
            IStatistics statisticsService = new StatisticsService();

            switch (option)
            {
                case "1":
                    string tableNumber, customerName;
                    bool bCustomeQty;
                    int customerQty;
                    CaseTakeAnOrder(tabels, showContentService, tableService, orderService, receiptService, statisticsService, out tableNumber, out customerName, out bCustomeQty, out customerQty);
                    break;
                case "2":
                    CaseReserveTable(tabels, showContentService, tableService, out tableNumber, out customerName, out bCustomeQty, out customerQty);
                    break;
                case "3":
                    tableNumber = CaseFreeUpTable(tabels, showContentService, tableService);
                    break;
                case "4":
                    CaseAddItem(showContentService);
                    break;
                case "5":
                    showContentService.PrintStatistics();

                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    //redirect
                    Redirect.RedirectTo("EmployeeMenu");
                    break;
                case "q":
                    Redirect.RedirectTo("EmployeeLogin");
                    break;
                default:
                    Thread.Sleep(3);
                    Console.Clear();

                    Redirect.RedirectTo("MainMenu");
                    break;
            }
            try
            {

            }
            catch (Exception)
            {
                Console.WriteLine(DataContent.ErrorsAndExceptionsData.ExceptionSomethingWrong);
            }

        }

        private void CaseAddItem(IShowContent showContentService)
        {
            Console.Clear();
            showContentService.ShowGreating();
            //Add food or drink
            showContentService.ShowChooseOption(DataContent.FoodMenuData.OptionOne,
                DataContent.FoodMenuData.OptionTwo,
                DataContent.FoodMenuData.OptionThree,
                DataContent.FoodMenuData.OptionFour,
                DataContent.FoodMenuData.OptionFive, "green");

            var addRemoveDrinkOrFood = Console.ReadLine();
            ChooseAddOrRemoveItemStep(addRemoveDrinkOrFood);
        }

        private string CaseFreeUpTable(Dictionary<string, Table> tabels, IShowContent showContentService, ITable tableService)
        {
            string tableNumber;
            Console.Clear();
            showContentService.ShowGreating();
            showContentService.PrintTalbeList(tabels);

            Console.WriteLine("Type the table number to free up the table and press ENTER:");
            tableNumber = Console.ReadLine();

            tableService.FreeUpTable(tableNumber, out bool successfullyFreedUp);

            if (successfullyFreedUp)
            {
                Console.WriteLine("The table is free now.");
                Thread.Sleep(3000);

                Console.Clear();
                showContentService.ShowGreating();
                showContentService.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                    DataContent.EmployeeMenuData.OptionTwo,
                    DataContent.EmployeeMenuData.OptionThree,
                    DataContent.EmployeeMenuData.OptionFour,
                    DataContent.EmployeeMenuData.OptionFive, "green");
                ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), TabelList);
            }

            if (!successfullyFreedUp)
            {
                Console.WriteLine("The table is free now.");
                Thread.Sleep(3000);

                Console.Clear();
                showContentService.ShowGreating();
                showContentService.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                    DataContent.EmployeeMenuData.OptionTwo,
                    DataContent.EmployeeMenuData.OptionThree,
                    DataContent.EmployeeMenuData.OptionFour,
                    DataContent.EmployeeMenuData.OptionFive, "green");
                ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), TabelList);
            }

            return tableNumber;
        }

        private static void CaseReserveTable(Dictionary<string, Table> tabels, IShowContent showContentService, ITable tableService, out string tableNumber, out string customerName, out bool bCustomeQty, out int customerQty)
        {
            Console.Clear();
            showContentService.ShowGreating();
            showContentService.PrintTalbeList(tabels);

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
            tableService.ReserveTable(tableNumber, customerName, _currentUser, customerQty);

            showContentService.RedirectMessage(DataContent.RedirectorsData.RedirectEmployeePage);
            Thread.Sleep(3000);
            Redirect.RedirectTo("EmployeeMenu");
        }

        private static void CaseTakeAnOrder(Dictionary<string, Table> tabels, IShowContent showContentService, ITable tableService, IOrder orderService, IReceipt receiptService, IStatistics statisticsService, out string tableNumber, out string customerName, out bool bCustomeQty, out int customerQty)
        {
            Console.Clear();
            showContentService.ShowGreating();
            showContentService.PrintTalbeList(tabels);

            Console.WriteLine("Type the table number and press ENTER:");
            tableNumber = Console.ReadLine();
            Console.WriteLine("Type the customer's name and surename then press ENTER:");
            customerName = Console.ReadLine();
            Console.WriteLine("Type the customer quantity and press ENTER:");
            bCustomeQty = int.TryParse(Console.ReadLine(), out customerQty);
            Console.Clear();

            if (!bCustomeQty)
            {
                Console.WriteLine("Enter the wrong age, try one more time. If you enter the age incorrectly, the employee's age will be saved as \"0\".");
                bCustomeQty = int.TryParse(Console.ReadLine(), out customerQty);
            }

            _currentTable = tableNumber;
            tableService.GetTable(tableNumber, customerName, _currentUser, customerQty);
            //Add print menu
            Helpers.MenuPrintAndAddSelectionHelper.MenuPrintAndAddSelection(out string selectedDrink, out string selectedFood);
            Console.Clear();

            Order newOrder = orderService.CreateOrder(selectedDrink, selectedFood);
            _currentOrder = newOrder.OrderId;

            orderService.StartOrder(newOrder);

            Receipt newReceipt = receiptService.CreateReceipt(Helpers.RandomIdHelper.RandomIdGenerator());
            receiptService.WriteInTheFileReceipt(newReceipt);
            statisticsService.WriteInTheFileReceipt(newReceipt);

            Console.WriteLine("Print receipt for customer? If YES type 'YES' and press Enter:");
            string printReceiptForCustomer = Console.ReadLine();

            if (printReceiptForCustomer.ToLower() == "yes")
            {
                showContentService.PrintReceiptForCustomer(newReceipt);
            }
            if (printReceiptForCustomer.ToLower() != "yes")
            {
                Console.WriteLine("Thank you for visiting our restaurant.");
                Thread.Sleep(3000);
            }

            showContentService.PrintReceiptForEmployee(newReceipt);

            orderService.EndOrder(newOrder.OrderId, _currentTable);
            //Redirect
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();

            Redirect.RedirectTo("EmployeeMenu");
        }

        public void ChooseAddOrRemoveItemStep(string option)
        {
            IShowContent showContentService = new ShowContentService();
            IItem itemService = new ItemService();

            switch (option)
            {
                case "1":
                    string nameOfItem, descriptionOfItem, unitOfMeasurementOfItem;
                    double QtyOfItem, PriceWithoutVatOfItem;
                    CaseAddDrink(showContentService, itemService, out nameOfItem, out descriptionOfItem, out unitOfMeasurementOfItem);
                    break;
                case "2":
                    string itemIdToEraseItemFromList = CaseRemoveDrink(showContentService, itemService);
                    break;
                case "3":
                    CaseAddMeal(showContentService, itemService, out nameOfItem, out descriptionOfItem, out unitOfMeasurementOfItem, out QtyOfItem, out PriceWithoutVatOfItem);
                    break;
                case "4":
                    itemIdToEraseItemFromList = CaseRemoveMeal(showContentService, itemService);
                    break;
                case "q":
                    Console.Clear();

                    ChooseEmployeeCreationOrLoginStep("2");
                    break;
                default:
                    Thread.Sleep(3);
                    Console.Clear();

                    Redirect.RedirectTo("MainMenu");
                    break;
            }
            try
            {

            }
            catch (Exception)
            {
                Console.WriteLine(DataContent.ErrorsAndExceptionsData.ExceptionSomethingWrong);
            }
        }

        private string CaseRemoveMeal(IShowContent showContentService, IItem itemService)
        {
            string itemIdToEraseItemFromList;
            Console.Clear();
            showContentService.ShowGreating();
            showContentService.PrintItemList(FoodList);

            Console.WriteLine("Type item ID to erase item and press ENTER:");
            itemIdToEraseItemFromList = Console.ReadLine();
            itemService.RemoveFood(itemIdToEraseItemFromList);

            Console.WriteLine(DataContent.RedirectorsData.EraseRedirectPreviousPage);
            Thread.Sleep(3000);

            ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep("4", TabelList);
            return itemIdToEraseItemFromList;
        }

        private void CaseAddMeal(IShowContent showContentService, IItem itemService, out string nameOfItem, out string descriptionOfItem, out string unitOfMeasurementOfItem, out double QtyOfItem, out double PriceWithoutVatOfItem)
        {
            Console.Clear();
            showContentService.ShowGreating();

            Console.WriteLine("Type an item name and press ENTER:");
            nameOfItem = Console.ReadLine();

            Console.WriteLine("Type an item description and press ENTER:");
            descriptionOfItem = Console.ReadLine();

            Console.WriteLine("Type an item unit of measurement and press ENTER:");
            unitOfMeasurementOfItem = Console.ReadLine();

            Console.WriteLine("Type an item quantity and press ENTER:");
            QtyOfItem = double.Parse(Console.ReadLine());

            Console.WriteLine("Type an item price without VAT and press ENTER:");
            PriceWithoutVatOfItem = double.Parse(Console.ReadLine());

            if (!Double.IsNaN(QtyOfItem) && !Double.IsNaN(PriceWithoutVatOfItem))
            {
                Item itemToAdd = new Item(Helpers.RandomIdHelper.RandomIdGenerator(), nameOfItem, _currentUser, descriptionOfItem, unitOfMeasurementOfItem, QtyOfItem, PriceWithoutVatOfItem);
                itemService.AddFood(itemToAdd);
            }
            else
            {
                Console.WriteLine(DataContent.RedirectorsData.WrongInputQuantityOrPriceOperationFailedRedirectPreviousPage);
                Thread.Sleep(3000);

                ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep("4", TabelList);
            }

            Console.WriteLine(DataContent.RedirectorsData.AddRedirectPreviousPage);
            Thread.Sleep(3000);

            ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep("4", TabelList);
            showContentService.ShowGreating();

            Console.WriteLine(DataContent.RedirectorsData.AddRedirectPreviousPage);
            Thread.Sleep(3000);

            ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep("4", TabelList);
        }

        private string CaseRemoveDrink(IShowContent showContentService, IItem itemService)
        {
            Console.Clear();
            showContentService.ShowGreating();
            showContentService.PrintItemList(DrinksList);

            Console.WriteLine("Type item ID to erase item and press ENTER:");
            string itemIdToEraseItemFromList = Console.ReadLine();
            itemService.RemoveDrink(itemIdToEraseItemFromList);

            Console.WriteLine(DataContent.RedirectorsData.EraseRedirectPreviousPage);
            Thread.Sleep(3000);

            ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep("4", TabelList);
            return itemIdToEraseItemFromList;
        }

        private void CaseAddDrink(IShowContent showContentService, IItem itemService, out string nameOfItem, out string descriptionOfItem, out string unitOfMeasurementOfItem)
        {
            Console.Clear();
            showContentService.ShowGreating();

            Console.WriteLine("Type an item name and press ENTER:");
            nameOfItem = Console.ReadLine();
            Console.WriteLine("Type an item description and press ENTER:");
            descriptionOfItem = Console.ReadLine();
            Console.WriteLine("Type an item unit of measurement and press ENTER:");
            unitOfMeasurementOfItem = Console.ReadLine();
            Console.WriteLine("Type an item quantity and press ENTER:");
            double QtyOfItem = double.Parse(Console.ReadLine());

            Console.WriteLine("Type an item price without VAT and press ENTER:");
            double PriceWithoutVatOfItem = double.Parse(Console.ReadLine());

            if (!Double.IsNaN(QtyOfItem) && !Double.IsNaN(PriceWithoutVatOfItem))
            {
                Item itemToAdd = new Item(Helpers.RandomIdHelper.RandomIdGenerator(), nameOfItem, _currentUser, descriptionOfItem, unitOfMeasurementOfItem, QtyOfItem, PriceWithoutVatOfItem);
                itemService.AddDrink(itemToAdd);
            }
            else
            {
                Console.WriteLine(DataContent.RedirectorsData.WrongInputQuantityOrPriceOperationFailedRedirectPreviousPage);
                Thread.Sleep(3000);

                ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep("4", TabelList);
            }

            Console.WriteLine(DataContent.RedirectorsData.AddRedirectPreviousPage);
            Thread.Sleep(3000);

            ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep("4", TabelList);
        }
    }
}
