using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IEmployee
    {
        internal Dictionary<string, Employee> AddEmployee(Employee newEmployee);
        internal bool LoginEmployee(string username, string password);
    }
}
