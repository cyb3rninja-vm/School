using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
namespace Школа
{
    public static class Storage
    {
        public static void CreateId(int id)
        {
            File.WriteAllText("id.txt", id.ToString());
        }

        public static int ReadId()
        {
            string path = "id.txt";
            if (!File.Exists(path))
                File.WriteAllText(path, "0");
            string id = File.ReadAllText(path);
            return int.Parse(id);
        }

        public static void WriteFile<T>(List<T> listAny)
        {
            string path = typeof(T).Name + ".txt";
            string jsonData = JsonConvert.SerializeObject(listAny);
            File.WriteAllText(path, jsonData);
        }
        public static List<T> ReadFile<T>(string path)
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "[]");
           
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static List<T> ReadFile<T>()
        {
            string path = typeof(T).Name + ".txt";
            if (!File.Exists(path))
                File.WriteAllText(path, "[]");

            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
