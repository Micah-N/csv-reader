﻿using System;
using System.IO;

namespace CSV_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running CSV -> JSON program\n");
            string file = null;
            try { file = FileUtils.GetReadFile(args); }
            catch(FileNotFoundException caught)
            {
                Console.WriteLine("\n**Caught an exception with the following details:**\n" + caught.ToString());
                Environment.Exit(-1);
            }
            if (FileUtils.TestFileHandle(file))
            {
                try { OutputJSON(FileUtils.ReadFile(file)); }
                catch (IndexOutOfRangeException caught)
                {
                    Console.WriteLine("\n**Caught an exception with the following details:**\n" + caught.ToString());
                    Environment.Exit(-1);
                }     
            }
        }   

        static void OutputJSON(Json target)
        {
            Console.WriteLine("Output results: \n" + target.ToString());
        }
    }
}