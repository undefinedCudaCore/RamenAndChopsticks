﻿using Newtonsoft.Json;

namespace RamenAndChopsticks.Helpers
{
    public static class ReadFromFileHelper<T>
    {

        public static Dictionary<string, T> ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    var jsonData = JsonConvert.DeserializeObject<Dictionary<string, T>>(File.ReadAllText(path));

                    if (jsonData == null)
                    {
                        jsonData = new Dictionary<string, T>();
                    }

                    List<KeyValuePair<string, T>> myList = jsonData.ToList();


                    //myList.Sort(
                    //    delegate (KeyValuePair<string, T> pair1,
                    //    KeyValuePair<string, T> pair2)
                    //    {
                    //        return pair1.Value.GetHashCode().CompareTo(pair2.Value.GetHashCode());
                    //    }
                    //);

                    return /*myList.ToDictionary()*/ jsonData;
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
