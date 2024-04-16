using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IItem
    {
        internal Dictionary<string, Item> AddDrink(Item newDrink);
        internal Dictionary<string, Item> AddFood(Item newFood);
    }
}
