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

        internal static class ErrorsAndExceptions
        {
            internal static readonly string Exception = "Fatal error, contact your system administrator..";
            internal static readonly string NullReferenceException = "A null value is given.";
            internal static readonly string FormatException = "Bad format value given.";

        }
    }
}
