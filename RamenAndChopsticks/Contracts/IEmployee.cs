using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IEmployee
    {
        internal Dictionary<string, Employee> AddEmployee(string id, string password, string name, string surname, int age, string gender, string jobTitle);
        internal Dictionary<string, Employee> LoadEmployee(string id, string password);
    }

}
