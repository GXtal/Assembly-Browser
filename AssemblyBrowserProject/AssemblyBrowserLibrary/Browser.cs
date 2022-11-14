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

        public Element WorkWith(string path)
        {
            try
            {
                workingAssembly = Assembly.LoadFrom(path);
            }
            catch
            {
                return new TreeHeaad("Error while loading assembly");
            }
            if(workingAssembly!=null)
            {
                var allTypes = workingAssembly.GetTypes();
                var temp = ParseAssembly(allTypes);
                var result = new TreeHeaad(temp);
                return result;
            }
            return new TreeHeaad("Smth went wrong");
        }
        public Element Temp()
        {
            var c = new TreeHeaad(true);
            return c;
        }

        public Dictionary<string, List<Type>> ParseAssembly(Type[] allTypes)
        {
            var result = new Dictionary<string, List<Type>>();
            foreach (var type in allTypes)
            {
                var space=type.Namespace;
                if(result.GetValueOrDefault(space)==null)
                {
                    result.Add(space, new List<Type>());
                }
                result[space].Add(type);
            }
            return result;
        }
        
    }
}
