using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace ClassLibrarLanguage.helpers
{
    public sealed class LoaderCsv:ILoader
    {
        
        public  IList<Tuple<string, string>> GetData(string file)
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            return lines.Select(t => t.Split(',')).Select(strings => new Tuple<string, string>(strings[0], strings[1])).ToList();
        }



    }
}