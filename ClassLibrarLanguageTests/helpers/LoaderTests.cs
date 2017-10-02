using System.Linq;
using System.Runtime.InteropServices;
using ClassLibrarLanguage.helpers;
using Xunit;

namespace ClassLibrarLanguageTests.helpers
{
    public class LoaderTests
    {
        [Fact()]
        public void GetDataTest()
        {
            ILoader loader=new LoaderCsv();

           var ret= loader.GetData(@"d:/data/cv.csv");
            Assert.True(ret.Any());
        }
    }
}