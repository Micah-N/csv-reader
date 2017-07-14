using System;
using System.Collections.Generic;
using System.IO;

namespace CSV_Reader
{
    public class FileUtils
    {
        public static string GetReadFile(string[] args)
        {
            if (Program.TestForArgs(args))
            {
                return args[args.Length - 1];
            }
            else
            {
                Console.WriteLine("Wasn't able to retrieve a file from your command line arguments, using a default test.csv");
                //throw new FileNotFoundException("No file given!"); //Comment this out to use default test.csv file
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
            List<string>[] values = new List<string>[results.Count - 1];
            InitListArray(values);

            //Get values
            for (int i = 1; i < results.Count; i++)
            {
                for (int j = 0; j < results[i].Length; j++)
                {
                    values[i - 1].Add(results[i][j]);
                }
            }
            //Initialize sorted value list
            List<string>[] sortedValues = new List<string>[keys.Length];
            InitListArray(sortedValues);
            
            //Sort values
            for (int k = 0; k < values.Length; k++)
            {
                for (int l = 0; l < values[k].Count; l++)
                {
                    sortedValues[l].Add(values[k][l]);
                }
            }
            return new Json() { Keys = keys, Values = sortedValues };
        }

        public static void InitListArray(List<string>[] target)
        {
            for(int i = 0; i < target.Length; i++) { target[i] = new List<string>(); }
        }
    }
}