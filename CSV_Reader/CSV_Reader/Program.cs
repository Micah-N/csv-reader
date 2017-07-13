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
                OutputJSON(FileUtils.ReadFile(file));
            }
            Console.ReadLine();
        }        

        public static bool TestForArgs(string[] target)
        {
            return (target.Length > 0);
        }        

        static void OutputJSON(Json target)
        {
            Console.WriteLine("Output results: \n" + target.ToString());            
        }
    }
}