using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVReader
{
    public class FileUtils
    {
        public static string GetDefaultFileHandle()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "test.csv");
        }

        public static bool TestFileHandle(string target)
        {
            return File.Exists(target);
        }

        public static Json ReadFile(string target)
        {
            StreamReader reader = new StreamReader(new FileStream(target, FileMode.Open));
            List<string[]> results = new List<string[]>();

            while (!reader.EndOfStream)
            {
                results.Add(reader.ReadLine().Split(','));
            }

            string[] keys = results[0];

            //Initialize values list
            List<string>[] values = CreateListArray(results.Count - 1);

            //Initialize sorted values list
            List<string>[] sortedValues = CreateListArray(keys.Length);

            //Get values
            for (int i = 0; i < results.Count - 1; i++)
            {
                for (int j = 0; j < results[i].Length; j++)
                {
                    values[i].Add(results[i + 1][j]);
                    sortedValues[j].Add(values[i][j]);
                }
            }
            
            return new Json()
            {
                Keys = keys,
                Values = sortedValues
            };
        }

        public static List<string>[] CreateListArray(int size)
        {
            return Enumerable.Range(0, size)
                .Select(index => new List<string>())
                .ToArray();
        }
    }
}