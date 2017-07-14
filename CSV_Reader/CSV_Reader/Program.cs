using System;
using System.IO;

namespace CSV_Reader
{
    internal class Program
    {
        private const int ErrorExitCode = -1;

        private const int NormalExitCode = 0;

        public static int Main(string[] args)
        {
            Console.WriteLine($"Running CSV -> JSON program {Environment.NewLine}");

            string file = null;
            try
            {
                file = FileUtils.GetReadFile(args);
            }
            catch(FileNotFoundException caught)
            {
                Console.WriteLine($"{Environment.NewLine}**Caught an exception with the following details:**{Environment.NewLine}{caught}");
                return ErrorExitCode;
            }

            if (FileUtils.TestFileHandle(file))
            {
                try
                {
                    OutputJSON(FileUtils.ReadFile(file));
                }
                catch (IndexOutOfRangeException caught)
                {
                    Console.WriteLine("\n**Caught an exception with the following details:**\n" + caught.ToString());
                    return ErrorExitCode;
                }     
            }

            return NormalExitCode;
        }   

        private static void OutputJSON(Json target)
        {
            Console.WriteLine("Output results: \n" + target.ToString());
        }
    }
}