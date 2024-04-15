using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Services;

namespace RamenAndChopsticks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Check and create the necessary data files.
            IDataFile dataFileCheckAndCreateService = new DataFileService();
            var dataFileNames = dataFileCheckAndCreateService.DataFileNames();
            dataFileCheckAndCreateService.CheckFilesExists(dataFileNames);
            dataFileCheckAndCreateService.DataFilesCreated(dataFileNames);

            //Print the welcome page; get the first user input;
            IShowContent showContentService = new ShowContentService();
            showContentService.ShowGreating();


        }
    }
}
