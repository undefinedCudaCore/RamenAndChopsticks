namespace RamenAndChopsticks.Data
{
    internal static class DataContent
    {
        internal static class HumanOptionData
        {
            internal static readonly string OptionOne = "\"1\" - Employee;";
            internal static readonly string OptionTwo = "\"2\" - Customer;";
            internal static readonly string OptionThree = "\"Q\" - Exit.";
        }

        internal static class EmployeeOptionData
        {
            internal static readonly string OptionOne = "\"1\" - Register a new employee.";
            internal static readonly string OptionTwo = "\"2\" - Choose a registered employee.";
            internal static readonly string OptionThree = "\"Q\" - Go to previous page.";
        }

        internal static class CustomerOptionData
        {
            internal static readonly string OptionOne = "\"1\" - Pass to the table.";
            internal static readonly string OptionTwo = "\"2\" - Choose a registered employee.";
            internal static readonly string OptionThree = "\"Q\" - Go to previous page.";
        }

        internal static class EmployeeMenuData
        {
            internal static readonly string OptionOne = "\"1\" - Take an order from the customer.";
            internal static readonly string OptionTwo = "\"2\" - Make a table reservation for the customer.";
            internal static readonly string OptionThree = "\"3\" - Free up table.";
            internal static readonly string OptionFour = "\"4\" - Add/Remove food or drink.";
            internal static readonly string OptionFive = "\"Q\" - Go to previous page.";
        }

        internal static class FoodMenuData
        {
            internal static readonly string OptionOne = "\"1\" - Add a drink.";
            internal static readonly string OptionTwo = "\"2\" - Remove the drink.";
            internal static readonly string OptionThree = "\"3\" - Add food.";
            internal static readonly string OptionFour = "\"4\" - Remove food.";
            internal static readonly string OptionFive = "\"Q\" - Go to previous page.";
        }

        internal static class ErrorsAndExceptionsData
        {
            internal static readonly string Exception = "Fatal error, contact your system administrator..";
            internal static readonly string ExceptionSomethingWrong = "Something went wrong; contact your system administrator...";
            internal static readonly string NullReferenceException = "A null value is given.";
            internal static readonly string FormatException = "Bad format value given.";

        }
        internal static class RedirectorsData
        {
            internal static readonly string EraseRedirectPreviousPage = "Erasing.. You will be redirected to the previous page..";
            internal static readonly string AddRedirectPreviousPage = "Adding data.. You will be redirected to the previous page..";
            internal static readonly string WrongInputOperationFailedRedirectPreviousPage = "Wrong qantity or price input.. Operation faile.. You will be redirected to the previous page..";
        }
    }
}
