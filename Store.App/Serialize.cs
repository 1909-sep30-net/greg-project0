using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using dom = Domains.Library;

namespace Store.App
{
    public static class Serialize
    {
        public static async Task JsonToFileAsync(string jsonFilePath, List<dom.Customer> data)
        {
            string json = JsonConvert.SerializeObject(data);

            // exceptions should be handled here, ignored for sake of time
            await File.WriteAllTextAsync(jsonFilePath, json);

        }

        public static async Task JsonToFileAsync(string jsonFilePath, List<dom.Product> data)
        {
            string json = JsonConvert.SerializeObject(data);

            // exceptions should be handled here, ignored for sake of time
            await File.WriteAllTextAsync(jsonFilePath, json);

        }

        public static async Task JsonToFileAsync(string jsonFilePath, List<dom.Location> data)
        {
            string json = JsonConvert.SerializeObject(data);

            // exceptions should be handled here, ignored for sake of time
            await File.WriteAllTextAsync(jsonFilePath, json);

        }

        public static async Task JsonToFileAsync(string jsonFilePath, List<dom.Order> data)
        {
            string json = JsonConvert.SerializeObject(data);

            // exceptions should be handled here, ignored for sake of time
            await File.WriteAllTextAsync(jsonFilePath, json);

        }

        public static async Task<List<dom.Customer>> DeserializeJsonFromFileAsync(string jsonFilePath)
        {
            
            string json;
            try
            {
                json = await File.ReadAllTextAsync(jsonFilePath);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Exception while trying to read file {file}", jsonFilePath);
                return null;
            }

            var data = JsonConvert.DeserializeObject<List<dom.Customer>>(json);

            return data;
        }

    }
}
