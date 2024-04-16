using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Services;

namespace RamenAndChopsticks
{
    internal class Program
    {
        internal static void Main()
        {
            //Check and create the necessary data files.
            IDataFile dataFileCheckAndCreateService = new DataFileService();
            var dataFileNames = dataFileCheckAndCreateService.DataFileNames();
            dataFileCheckAndCreateService.CheckFilesExists(dataFileNames);
            dataFileCheckAndCreateService.DataFilesCreated(dataFileNames);

            IItem itemService = new ItemService();
            //itemService.AddDrink(new Models.Item(1, 5, 5, 7, "Cola", "Not good", "Litres"));
            //itemService.AddFood(new Models.Item(1, 5, 5, 7, "Cola", "Not good", "Litres"));
            itemService.RemoveFood(1);
            //TableService tableService = new TableService();
            //tableService.GetTable("1", "tad", "tom", 3);
            //IEmployee employeeService = new EmployeeService();
            //employeeService.AddEmployee(new Employee("7777", "123tadas321*", "Tadas", "Blinda", 25, "Male", "waitrun"));

            ChooseHuman();
        }

        internal static void ChooseHuman()
        {
            //Print the welcome page;
            IShowContent showContentService = new ShowContentService();
            showContentService.ShowGreating();

            // Get the first user input (choose emplyee or customer);
            showContentService.ShowChooseOption(DataContent.HumanOptionData.OptionOne,
                DataContent.HumanOptionData.OptionTwo,
                DataContent.HumanOptionData.OptionThree, "RED");

            var chooseHumanOption = Console.ReadLine();
            ISteps stepsService = new StepsService();
            stepsService.ChooseHumanOptionStep(chooseHumanOption.ToLower());
        }
    }
}
