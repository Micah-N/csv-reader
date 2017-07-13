using System;
using System.Collections.Generic;
using System.IO;

namespace CSV_Reader
{
    public class FileUtils
    {
        public FileUtils()
        {
        }

        public static string GetReadFile(string[] args)
        {
            if (Program.TestForArgs(args))
            {
                return args[args.Length - 1];
            }
            else
            {
                return GetDefaultFileHandle(); //Used for setting up a default test file, remove if not needed
            }
        }

        public static string GetDefaultFileHandle()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "test.csv");
        }

        public static bool TestFileHandle(string target)
        {
            return File.Exists(target);
        }

        public static Dictionary<string, List<string>> ReadFile(string target)
        {
            StreamReader reader = new StreamReader(new FileStream(target, FileMode.Open));
            List<string[]> results = new List<string[]>();

            while (!reader.EndOfStream)
            {
                results.Add(reader.ReadLine().Split(','));
            }

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            string[] keys = results[0];
            List<string>[] values = new List<string>[keys.Length];
            //Initialize values
            for(int i = 0; i < values.Length; i++)
            {
                values[i] = new List<string>();
            }
            //CheckFileContents(results);
            for (int i = 1; i < results.Count; i++)
            {
                Console.WriteLine(results[i]);
                for (int j = 0; j < results[i].Length; j++)
                {
                    Console.WriteLine("Col#" + i + ", value#" + j + ": " + results[i][j]);
                    Console.WriteLine(results[i][j].GetType());
                    values[i - 1].Add(results[i][j]);//This isn't being assigned correctly                    
                }
            }
            List<string>[] sortedValues = new List<string>[keys.Length];
            for(int i = 0; i < sortedValues.Length; i++)
            {
                sortedValues[i] = new List<string>();
            }
            for (int k = 0; k < values.Length; k++)
            {
                for (int l = 0; l < values[k].Count; l++)
                {
                    Console.WriteLine("Col#" + k + ", value#" + l + ": " + values[k][l]);
                    sortedValues[l].Add(values[k][l]);
                }
            }
            for (int k = 0; k < sortedValues.Length; k++)
            {
                for (int l = 0; l < sortedValues[k].Count; l++)
                {
                    Console.WriteLine("Sorted Values#" + k + ", value#" + l + ": " + sortedValues[k][l]);
                }
                dict.Add(keys[k], sortedValues[k]);
            }
            return dict;
        }

        static void CheckFileContents(List<string[]> target)
        {
            for (int i = 1; i < target.Count; i++)
            {
                Console.WriteLine(target[i]);
                for (int j = 0; j < target[i].Length; j++)
                {
                    Console.WriteLine("Col#" + i + ", value#" + j + ": " + target[i][j]);
                }
            }
        }
    }
}
