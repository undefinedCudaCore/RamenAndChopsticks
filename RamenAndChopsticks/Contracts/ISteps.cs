namespace RamenAndChopsticks.Contracts
{
    public interface ISteps
    {
        public void ChooseHumanOptionStep(string option);
        public void ChooseTableOrReservationStep(string option);
    }
}
