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
            string file;
            if (TestForArgs(args))
            {
                file = args[args.Length-1];
                Console.WriteLine("argument length: " + args.Length);               
            }
            else
            {
                file = GetDefaultFileHandle(); //Used for setting up a default test file, remove if not needed
            }
            Console.WriteLine("File: " + file);
            if (TestFileHandle(file))
            {
                OutputResults(ReadFile(file));
            }
            Console.ReadLine();
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

        static List<string[]> ReadFile(string target)
        {
            StreamReader reader = new StreamReader(new FileStream(target, FileMode.Open));
            List<string[]> results = new List<string[]>();

            while (!reader.EndOfStream)
            {
                results.Add(reader.ReadLine().Split(','));
            }
            
            return results;
        }

        static void OutputResults(List<string[]> target)
        {
            int wordcount = 0;
            foreach (string[] str in target)
            {
                foreach (string line in str)
                {
                    wordcount++;
                    Console.WriteLine("Word #" + wordcount + ": " + line);
                }
            }
        }
    }
}