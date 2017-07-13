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

        static void OutputJSON(Dictionary<string, List<string>> target)
        {
            string results = "[\n\t{\n\t";
            /*
            [
  {
    "Alpha": "Apple",
    "Beta": "Banana",
    "Gamma": "Grape"
  },
  {
    "Alpha": "Ant",
    "Beta": "Bat",
    "Gamma": "Gorilla"
  }
]
 
            */
            int wordcount = 0;
            for(int key = 0; key < target.Count; key++)
            {
                //Want to iterate through target dictionary to allow for better JSON formatting
            }
            foreach (KeyValuePair<string, List<string>> pair in target)
            {
                wordcount++;
                string key = pair.Key;
                List<string> value = pair.Value;

                foreach(string val in value)
                {
                    Console.WriteLine("\tWord #" + wordcount + ": " + " key: " + key + " value: " + val);
                }
                results += "";
            }
        }
    }
}