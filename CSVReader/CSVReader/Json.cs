using System;
using System.Collections.Generic;

namespace CSVReader
{
    public class Json
    {
        public string[] Keys { get; set; }
        public List<string>[] Values { get; set; }
        
        public override string ToString()
        {
            string spaces = "    "; //string holds four spaces for cleaner formatting (looks better than "\t")
            string results = $"{{{Environment.NewLine}  [";
            for(int value = 0; value < this.Values[0].Count; value++)
            {
                results += $"{Environment.NewLine}" + spaces + "{";
                for (int key = 0; key < this.Keys.Length; key++)
                {
                    string val = this.Values[key][value];
                    results += $"{Environment.NewLine} {spaces}{spaces}" + '"' + this.Keys[key].Trim() + '"' + ": " + '"' + val.Trim() + '"';
                    if(key < this.Keys.Length - 1) { results += ","; }
                }
                results += $"{Environment.NewLine}{spaces}" + "}";              
                if(value < this.Values[0].Count - 1) { results += ","; }
            }
            results += $"{Environment.NewLine}" + $"  ]{ Environment.NewLine}" + "}";
            return results;
        }
    }
}