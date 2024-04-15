namespace RamenAndChopsticks.Contracts
{
    public interface IShowContent
    {
        public void ShowGreating();
        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string color);
        public void ShowReturnToMainMenu(string errorNumber);
    }
}
