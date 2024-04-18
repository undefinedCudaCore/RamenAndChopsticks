using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface ISteps
    {
        public void ChooseHumanOptionStep(string option);
        internal void ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(string option, Dictionary<string, Table> tabels);
        public void ChooseEmployeeCreationOrLoginStep(string option);
    }
}
