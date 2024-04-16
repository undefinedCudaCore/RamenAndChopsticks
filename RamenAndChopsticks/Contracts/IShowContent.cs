namespace RamenAndChopsticks.Contracts
{
    public interface IShowContent
    {
        public void ShowGreating();
        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string color);
        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string optionFour, string color);
        public void ShowChooseOption(string optionOne, string optionTwo, string optionThree, string optionFour, string optionFive, string color);
        public void ShowReturnToMainMenu(string errorNumber);
        public void ShowReturnToMainMenu(string username, string password);
    }
}
