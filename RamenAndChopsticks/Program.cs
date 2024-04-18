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
            dataFileCheckAndCreateService.CreateDataFiles(dataFileNames);

            //Check and create the necessary data.
            ITable tableService = new TableService();
            tableService.CreateTableListIfFileIsEmpty(TableService._maxTables, TableService._tableSpaces);

            MainMenu();
        }

        internal static void MainMenu()
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
