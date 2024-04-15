using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class EmployeeService : IEmployee
    {
        private readonly Dictionary<string, Employee> _employeeList = Helpers.ReadFromFileHelper<Employee>.ReadFromFile(Data.DataFilePath.EmployeesInfoPath);
        public Dictionary<string, Employee> AddEmployee(Employee newEmployee)
        {
            foreach (var employee in _employeeList)
            {
                if (employee.Value.EmployeeUsername == newEmployee.EmployeeUsername)
                {
                    IShowContent showContentService = new ShowContentService();
                    showContentService.ShowReturnToMainMenu("5214");
                    Thread.Sleep(3000);

                    return _employeeList;
                }
            }
            _employeeList.Add(Helpers.RandomIdHelper.RandomIdGenerator(), newEmployee);

            Helpers.WriteToFileHelper<Employee>.WriteToFile(_employeeList, Data.DataFilePath.EmployeesInfoPath);

            return _employeeList;
        }

        public Dictionary<string, Employee> LoginEmployee(string id, string password)
        {
            throw new NotImplementedException();
        }
    }
}
