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

            string file = FileUtils.GetReadFile(args);
            
            Console.WriteLine("File: " + file);
            if (FileUtils.TestFileHandle(file))
            {
                OutputResults(FileUtils.ReadFile(file));
            }
            Console.ReadLine();
        }        

        public static bool TestForArgs(string[] target)
        {
            return (target.Length > 0);
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