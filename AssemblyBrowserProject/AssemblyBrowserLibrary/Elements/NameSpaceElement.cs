using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class NameSpaceElement:Element
    {
        public NameSpaceElement(string name, bool a)
        {
            Childs = new List<Element>();
            Name = name;
            Childs.Add(new TypeElement("nya", true));
            Childs.Add(new TypeElement("uhh", true));
        }
    }
}
