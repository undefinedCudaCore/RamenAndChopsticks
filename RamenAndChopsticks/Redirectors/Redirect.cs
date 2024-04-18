using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Data;
using RamenAndChopsticks.Models;
using RamenAndChopsticks.Services;

namespace RamenAndChopsticks.Redirectors
{
    internal static class Redirect
    {
        private static Dictionary<string, Table> TabelList = Helpers.ReadFromFileHelper<Table>.ReadFromFile(DataFilePath.TableInfoPath);

        internal static void RedirectTo(string redirectData)
        {
            redirectData = redirectData.ToLower();

            switch (redirectData)
            {
                case "mainmenu":
                    Program.MainMenu();
                    break;
                case "employeemenu":
                    IShowContent showContentService = new ShowContentService();
                    ISteps stepsService = new StepsService();

                    showContentService.RedirectMessage(DataContent.RedirectorsData.RedirectMainPage);
                    Thread.Sleep(3000);

                    Console.Clear();
                    showContentService.ShowGreating();
                    showContentService.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                        DataContent.EmployeeMenuData.OptionTwo,
                        DataContent.EmployeeMenuData.OptionThree,
                        DataContent.EmployeeMenuData.OptionFour,
                        DataContent.EmployeeMenuData.OptionFive, "green");
                    stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), TabelList);
                    break;
                default:
                    Program.MainMenu();
                    break;
            }
        }
    }
}
