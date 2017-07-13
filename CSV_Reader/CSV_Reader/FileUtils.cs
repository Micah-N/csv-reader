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

        public static Dictionary<string, string[]> ReadFile(string target)
        {
            StreamReader reader = new StreamReader(new FileStream(target, FileMode.Open));
            List<string[]> results = new List<string[]>();

            while (!reader.EndOfStream)
            {
                results.Add(reader.ReadLine().Split(','));
            }

            Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
            string[] keys = results[0];
            string[,] values = new string[keys.Length, results.Count-1];
            CheckFileContents(results);
            /*
            for (int i = 1; i < results.Count; i++)
            {
                for (int j = 0; j < results[i].Length; j++)
                {
                    values[j] = results[i][j]; //This needs to be adjusted
                }
                dict.Add(keys[i - 1], values[i-1]);
            }
            */            
            return dict;
        }

        static void CheckFileContents(List<string[]> target)
        {
            for (int i = 0; i < target.Count; i++)
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
