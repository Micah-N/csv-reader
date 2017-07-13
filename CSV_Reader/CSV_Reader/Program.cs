using System;
using System.Collections.Generic;
using System.IO;

namespace CSV_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            if (TestForArgs(args))
            {
                string file = args[args.Length-1];
                Console.WriteLine("argument length: " + args.Length);
                Console.WriteLine("File: " + file);
                if (TestFileHandle(file))
                {
                    OutputResults(ReadFile(file));
                }
            }
            else
            {
                Console.WriteLine("Please enter console arguments.");
            }
            Console.ReadLine();
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