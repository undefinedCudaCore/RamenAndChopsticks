namespace RamenAndChopsticks.Contracts
{
    public interface ISteps
    {
        public void ChooseHumanOptionStep(string option);
        public void ChooseTakeOrderOrMakeReservationOrAddFoodAndDrinksStep(string option);
        public void ChooseEmployeeCreationOrLoginStep(string option);
    }
}
