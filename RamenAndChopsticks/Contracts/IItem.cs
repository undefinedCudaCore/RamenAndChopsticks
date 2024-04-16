namespace RamenAndChopsticks.Contracts
{
    public interface IItem
    {
        public Dictionary<string, string> AddDrink();
        public Dictionary<string, string> AddFood();
    }
}
