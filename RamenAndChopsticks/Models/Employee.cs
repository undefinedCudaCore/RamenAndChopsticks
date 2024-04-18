namespace RamenAndChopsticks.Models
{
    internal class Employee
    {
        public Employee()
        {
        }

        public Employee(string employeeId, string employeePasword, string employeeName, string employeeSurename, int employeeAge, string employeeGender, string employeeJobTitle)
        {
            EmployeeUsername = employeeId;
            EmployeePassword = employeePasword;
            EmployeeName = employeeName;
            EmployeeSurename = employeeSurename;
            EmployeeAge = employeeAge;
            EmployeeGender = employeeGender;
            EmployeeJobTitle = employeeJobTitle;
        }

        public string EmployeeUsername { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurename { get; set; }
        public int EmployeeAge { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeJobTitle { get; set; }
    }
}
