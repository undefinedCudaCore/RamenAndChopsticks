using Newtonsoft.Json;

namespace RamenAndChopsticks.Helpers
{
    internal static class WriteToFileHelper<T>
    {
        public static void WriteToFile(Dictionary<string, T> dic, string path)
        {
            var jsonData = JsonConvert.SerializeObject(dic);

            File.WriteAllText(path, jsonData);
        }
    }
}
