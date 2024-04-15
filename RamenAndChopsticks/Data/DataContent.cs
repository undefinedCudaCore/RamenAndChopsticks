namespace RamenAndChopsticks.Data
{
    internal static class DataContent
    {
        internal static class HumanOptionData
        {
            internal static readonly string OptionOne = "\"1\" - Employee;";
            internal static readonly string OptionTwo = "\"2\" - Customer;";
            internal static readonly string OptionThree = "\"Q\" - Go to welcome page.";
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
    }
}
