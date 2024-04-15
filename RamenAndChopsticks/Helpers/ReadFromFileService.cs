using Newtonsoft.Json;
using RamenAndChopsticks.Contracts;

namespace RamenAndChopsticks.Helpers
{
    internal class ReadFromFileService<T> : IReadFile<T> where T : class
    {

        public Dictionary<string, T> ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    var jsonData = JsonConvert.DeserializeObject<Dictionary<string, T>>(File.ReadAllText(path));
                    List<KeyValuePair<string, T>> myList = jsonData.ToList();

                    myList.Sort(
                        delegate (KeyValuePair<string, T> pair1,
                        KeyValuePair<string, T> pair2)
                        {
                            return pair1.Value.GetHashCode().CompareTo(pair2.Value.GetHashCode());
                        }
                    );

                    return myList.ToDictionary();
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("File directory was not found.");
                    return new Dictionary<string, T>();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File was not found");
                    return new Dictionary<string, T>();
                }
                catch (Exception)
                {
                    Console.WriteLine("Other important error..Contact the developer.");
                    return new Dictionary<string, T>();
                }
            }
            else
            {
                return new Dictionary<string, T>();
            }
        }

    }
}
