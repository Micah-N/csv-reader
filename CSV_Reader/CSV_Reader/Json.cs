using System;
using System.Collections.Generic;
using System.Text;

namespace CSV_Reader
{
    public class Json
    {
        public string[] Keys { get; set; }
        public List<string>[] Values { get; set; }

        override
        public string ToString()
        {
            string tabs = "    "; //string holds four tabs for cleaner formatting
            string results = "{\n  [\n    ";
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
            
            for (int key = 0; key < this.Keys.Length; key++)
            {
                results += "\n" + tabs + "{";
                //Want to iterate through target dictionary to allow for better JSON formatting
                for(int value = 0; value < this.Values[key].Count; value++)
                {
                    string val = this.Values[key][value];                    
                    results += "\n" + tabs + tabs +"Key ->" + '"' + this.Keys[key].Trim() + '"' + ": " + " Value -> " + '"' + val.Trim() + '"';
                    if (value < this.Values[key].Count - 1) { results += ","; }
                }
                results += "\n" +  tabs + "}";
                if(key < this.Keys.Length - 1) { results += ","; }
            }

            results += "\n    }\n  ]\n}";
            return results;
        }
    }
}