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
            IShowContent showContentService = new ShowContentService();
            ISteps stepsService = new StepsService();

            switch (redirectData)
            {
                case "mainmenu":
                    Program.MainMenu();
                    break;
                case "employeemenu":

                    showContentService.RedirectMessage(DataContent.RedirectorsData.RedirectEmployeePage);
                    Thread.Sleep(3000);

                    Console.Clear();
                    showContentService.ShowGreating();
                    showContentService.ShowChooseOption(DataContent.EmployeeMenuData.OptionOne,
                        DataContent.EmployeeMenuData.OptionTwo,
                        DataContent.EmployeeMenuData.OptionThree,
                        DataContent.EmployeeMenuData.OptionFour,
                        DataContent.EmployeeMenuData.OptionSix,
                        DataContent.EmployeeMenuData.OptionFive, "green");
                    stepsService.ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(Console.ReadLine(), TabelList);
                    break;
                case "employeelogin":
                    Console.Clear();
                    showContentService.ShowGreating();
                    showContentService.ShowChooseOption(DataContent.EmployeeOptionData.OptionOne,
                        DataContent.EmployeeOptionData.OptionTwo,
                        DataContent.EmployeeOptionData.OptionThree, "green");

                    StepsService._choices[0] = "1";
                    stepsService.ChooseEmployeeCreationOrLoginStep(Console.ReadLine());
                    break;
                default:
                    Program.MainMenu();
                    break;
            }
        }
    }
}
