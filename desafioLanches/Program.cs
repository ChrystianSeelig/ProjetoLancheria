using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace desafioLanches
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Lanches> lanches = new();

                string fileName = "desafiolanches.json";
                string path = Path.Combine(Environment.CurrentDirectory, fileName);

                FileInfo fileTest = new(path);

                if (fileTest.Exists == false)
                {
                    File.WriteAllText(path, JsonConvert.SerializeObject(lanches));
                }

                using (StreamReader stream = new(path))
                {
                    string jsonString = stream.ReadToEnd();
                    lanches = JsonConvert.DeserializeObject<List<Lanches>>(jsonString);
                }

                Menus.MainMenu(lanches);
            }
            catch (SystemException ex)
            {
                Console.WriteLine($"Ocorreu um problema e o programa vai encerrar. Detalhes: {ex.Message}");
            }
        }
    }
}
