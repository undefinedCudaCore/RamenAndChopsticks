using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Contracts
{
    public interface IItem
    {
        internal Dictionary<string, Item> AddDrink(Item newDrink);
        internal Dictionary<string, Item> RemoveDrink(int drinkId);
        internal Dictionary<string, Item> AddFood(Item newFood);
        internal Dictionary<string, Item> RemoveFood(int foodId);
    }
}
