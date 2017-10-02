using System;
using System.Collections.Generic;
using System.IO;

namespace ClassLibrarLanguage.helpers
{
    public interface ILoader
    {
        IList<Tuple<String, String>> GetData(string file);
    }
}