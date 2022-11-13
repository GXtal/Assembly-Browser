using AssemblyBrowserLibrary.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary
{
    public class Browser
    {
        private Assembly? workingAssembly;

        public Browser()
        {

        }

        public void WorkWith(string path)
        {
            workingAssembly = Assembly.LoadFrom(path);
            //var allTypes = workingAssembly.GetTypes();
            

        }

        public Element Temp()
        {
            var c = new TreeHeaad(true);
            return c;
        }
    }
}
