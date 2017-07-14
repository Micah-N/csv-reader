using System.Collections.Generic;

namespace CSV_Reader
{
    public class Json
    {
        public string[] Keys { get; set; }
        public List<string>[] Values { get; set; }

        override
        public string ToString()
        {
            string spaces = "    "; //string holds four spaces for cleaner formatting (looks better than "\t")
            string results = "{\n  [";
            for(int value = 0; value < this.Values[0].Count; value++)
            {
                results += "\n" + spaces + "{";
                for (int key = 0; key < this.Keys.Length; key++)
                {
                    string val = this.Values[key][value];
                    results += "\n" + spaces + spaces + '"' + this.Keys[key].Trim() + '"' + ": " + '"' + val.Trim() + '"';
                    if(key < this.Keys.Length - 1) { results += ","; }
                }
                results += "\n" + spaces + "}";              
                if(value < this.Values[0].Count - 1) { results += ","; }
            }
            results += "\n  ]\n}";
            return results;
        }
    }
}