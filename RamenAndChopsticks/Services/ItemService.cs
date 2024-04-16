using RamenAndChopsticks.Contracts;
using RamenAndChopsticks.Models;

namespace RamenAndChopsticks.Services
{
    internal class ItemService : IItem
    {
        private Dictionary<string, Item> DrinksList = Helpers.ReadFromFileHelper<Item>.ReadFromFile(Data.DataFilePath.DrinksInfoPath);
        private Dictionary<string, Item> FoodList = Helpers.ReadFromFileHelper<Item>.ReadFromFile(Data.DataFilePath.FoodInfoPath);

        public Dictionary<string, Item> AddDrink(Item newDrink)
        {
            try
            {
                DrinksList.Add(Helpers.RandomIdHelper.RandomIdGenerator(), newDrink);

                Helpers.WriteToFileHelper<Item>.WriteToFile(DrinksList, Data.DataFilePath.DrinksInfoPath);

                return DrinksList;

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(Data.DataContent.ErrorsAndExceptions.NullReferenceException);
            }
            catch (FormatException)
            {
                throw new FormatException(Data.DataContent.ErrorsAndExceptions.FormatException);
            }
            catch (Exception)
            {
                throw new Exception(Data.DataContent.ErrorsAndExceptions.Exception);
            }
        }

        public Dictionary<string, Item> RemoveDrink(int drinkId)
        {
            foreach (var item in DrinksList.Where(kvp => kvp.Value.ItemId == drinkId).ToList())
            {
                DrinksList.Remove(item.Key);
            }

            Helpers.WriteToFileHelper<Item>.WriteToFile(DrinksList, Data.DataFilePath.DrinksInfoPath);

            return DrinksList;
        }

        public Dictionary<string, Item> AddFood(Item newFood)
        {
            try
            {
                FoodList.Add(Helpers.RandomIdHelper.RandomIdGenerator(), newFood);

                Helpers.WriteToFileHelper<Item>.WriteToFile(FoodList, Data.DataFilePath.FoodInfoPath);

                return FoodList;

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(Data.DataContent.ErrorsAndExceptions.NullReferenceException);
            }
            catch (FormatException)
            {
                throw new FormatException(Data.DataContent.ErrorsAndExceptions.FormatException);
            }
            catch (Exception)
            {
                throw new Exception(Data.DataContent.ErrorsAndExceptions.Exception);
            }
        }

        public Dictionary<string, Item> RemoveFood(int foodId)
        {
            foreach (var item in FoodList.Where(kvp => kvp.Value.ItemId == foodId).ToList())
            {
                FoodList.Remove(item.Key);
            }

            Helpers.WriteToFileHelper<Item>.WriteToFile(FoodList, Data.DataFilePath.FoodInfoPath);

            return FoodList;
        }

    }
}
