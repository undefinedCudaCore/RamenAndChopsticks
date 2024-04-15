using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class EmployeeService : IEmployee
    {
        public Dictionary<string, Employee> AddEmployee(Employee newEmployee)
        {
            try
            {
                Dictionary<string, Employee> employeeList = Helpers.ReadFromFileHelper<Employee>.ReadFromFile(Data.DataFilePath.EmployeesInfoPath);

                foreach (var employee in employeeList)
                {
                    if (employee.Value.EmployeeUsername == newEmployee.EmployeeUsername)
                    {
                        IShowContent showContentService = new ShowContentService();
                        showContentService.ShowReturnToMainMenu("5214");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Program.Main();

                        return employeeList;
                    }
                }
                employeeList.Add(Helpers.RandomIdHelper.RandomIdGenerator(), newEmployee);

                Helpers.WriteToFileHelper<Employee>.WriteToFile(employeeList, Data.DataFilePath.EmployeesInfoPath);

                return employeeList;

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(Data.DataContent.ErrorsAndExceptions.NullReferenceException);
            }
            catch (FormatException)
            {
                throw new FormatException(Data.DataContent.ErrorsAndExceptions.FormatException);
            }
            catch (Exception)
            {
                throw new Exception(Data.DataContent.ErrorsAndExceptions.Exception);
            }
        }

        public Dictionary<string, Employee> LoginEmployee(string id, string password)
        {
            throw new NotImplementedException();
        }
    }
}
