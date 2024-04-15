namespace RamenAndChopsticks.Contracts
{
    public interface IReadFile<T>
    {
        public Dictionary<string, T> ReadFromFile(string path);
    }
}
