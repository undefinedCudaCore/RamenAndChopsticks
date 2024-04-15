using RamenAndChopsticks.Contracts;
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

            //Print the welcome page;
            IShowContent showContentService = new ShowContentService();
            showContentService.ShowGreating();

            // Get the first user input (choose emplyee or customer);
            showContentService.ShowChooseHumanOption();

            var chooseHumanOption = Console.ReadLine();
            StepsService stepsService = new StepsService();
            stepsService.ChooseHumanOptionStep(chooseHumanOption);
        }
    }
}
