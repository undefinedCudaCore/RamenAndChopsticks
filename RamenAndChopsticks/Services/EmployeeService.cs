using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class EmployeeService : IEmployee
    {
        Dictionary<string, Employee> IEmployee.AddEmployee(string id, string password, string name, string surname, int age, string gender, string jobTitle)
        {
            throw new NotImplementedException();
        }

        Dictionary<string, Employee> IEmployee.LoadEmployee(string id, string password)
        {
            throw new NotImplementedException();
        }
    }
}
