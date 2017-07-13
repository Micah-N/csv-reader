using System;
using System.Collections.Generic;
using System.IO;

namespace CSV_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");

            string file = GetReadFile(args);
            
            Console.WriteLine("File: " + file);
            if (TestFileHandle(file))
            {
                OutputResults(ReadFile(file));
            }
            Console.ReadLine();
        }

        static string GetReadFile(string[] args)
        {
            if (TestForArgs(args))
            {
                return args[args.Length - 1];
            }
            else
            {
                return GetDefaultFileHandle(); //Used for setting up a default test file, remove if not needed
            }
        }

        static string GetDefaultFileHandle()
        {            
            return Path.Combine(Directory.GetCurrentDirectory(), "test.csv");
        }

        static bool TestForArgs(string[] target)
        {
            return (target.Length > 0);
        }

        static bool TestFileHandle(string target)
        {
            return File.Exists(target);
        }

        static Dictionary<string, string[]> ReadFile(string target)
        {
            StreamReader reader = new StreamReader(new FileStream(target, FileMode.Open));
            List<string[]> results = new List<string[]>();
            
            while (!reader.EndOfStream)
            {
                results.Add(reader.ReadLine().Split(','));
            }

            Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
            string[] keys = results[0];
            string[] temp = new string[results.Count];
            for(int i = 1; i < results.Count; i++)
            {
                for(int j = 0; j < results[i].Length; j++)
                {
                    temp[j] = results[i][j]; //This needs to be adjusted
                }
                dict.Add(keys[i-1], temp);
            }
            return dict;
        }

        static void OutputResults(Dictionary<string, string[]> target)
        {
            int wordcount = 0;
            foreach (KeyValuePair<string, string[]> pair in target)
            {
                wordcount++;
                string key = pair.Key;
                string[] value = pair.Value;
                foreach(string val in value)
                {
                    Console.WriteLine("Word #" + wordcount + ": " + " key: " + key + " value: " + val);
                }                
            }
        }
    }
}