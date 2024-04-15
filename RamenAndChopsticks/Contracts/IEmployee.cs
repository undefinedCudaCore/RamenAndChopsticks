using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IEmployee
    {
        internal Dictionary<string, Employee> AddEmployee(Employee newEmployee);
        internal Dictionary<string, Employee> LoginEmployee(string id, string password);
    }
}
