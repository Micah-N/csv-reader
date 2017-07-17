using System;
using System.IO;
using System.Linq;

namespace CSVReader
{
    public class Program
    {
        private const int ErrorExitCode = -1;
        private const int NormalExitCode = 0;

        public static int Main(string[] args)
        {
            Console.WriteLine($"Running CSV -> JSON program{Environment.NewLine}");

            string file = null;
            try
            {
                file = ParseArgs(args);
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
                    Console.WriteLine($"{Environment.NewLine}**Caught an exception with the following details:**{Environment.NewLine}{caught}");
                    return ErrorExitCode;
                }     
            }
            return NormalExitCode;
        }

        private static string ParseArgs(string[] args)
        {
            if ((args.Length == 1))
            {
                return args.Single();
            }

            Console.WriteLine($"Wasn't able to retrieve a file from your command line arguments, using a default test.csv{Environment.NewLine}");
            //throw new FileNotFoundException("No file given!"); //Comment this out to use default test.csv file
            return FileUtils.GetDefaultFileHandle(); //Used for setting up a default test file, remove if not needed
        }

        private static void OutputJSON(Json target)
        {
            Console.WriteLine($"Output results: {Environment.NewLine}{target.ToString()}");
        }
    }
}