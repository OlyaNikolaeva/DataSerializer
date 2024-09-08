using System.Diagnostics;

namespace DataCsvSerializer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var instance = F.Get();
            var iterations = 100000;

            // Замер времени на сериализацию
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                var csv = CsvSerializer.Serialize(instance);
            }
            sw.Stop();
            Console.WriteLine($"CSV Serialization Time: {sw.ElapsedMilliseconds} ms");

            // Замер времени на десериализацию
            var csvSerialized = CsvSerializer.Serialize(instance);
            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                var deserialized = CsvSerializer.Deserialize<F>(csvSerialized);
            }
            sw.Stop();
            Console.WriteLine($"CSV Deserialization Time: {sw.ElapsedMilliseconds} ms");

            // Сравнение с Newtonsoft.Json
            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(instance);
            }
            sw.Stop();
            Console.WriteLine($"JSON Serialization Time (Newtonsoft): {sw.ElapsedMilliseconds} ms");

            var jsonSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(instance);
            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<F>(jsonSerialized);
            }
            sw.Stop();
            Console.WriteLine($"JSON Deserialization Time (Newtonsoft): {sw.ElapsedMilliseconds} ms");
        }
    }
}
