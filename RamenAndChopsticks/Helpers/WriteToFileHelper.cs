using Newtonsoft.Json;

namespace RamenAndChopsticks.Helpers
{
    public static class WriteToFileHelper<T>
    {
        public static void WriteToFile(Dictionary<string, T> dic, string path)
        {
            var jsonData = JsonConvert.SerializeObject(dic, Formatting.Indented);

            File.WriteAllText(path, jsonData);
        }
    }
}
