using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class NameSpaceElement:Element
    {
        public NameSpaceElement(string name, List<Type> types)
        {
            Name = name;
            Childs = new List<Element>();
            foreach(var type in types)
            {
                if(!type.IsDefined(typeof(CompilerGeneratedAttribute),false))
                {
                    Childs.Add(new TypeElement(type));
                }
                
            }
        }
        public NameSpaceElement(string name, bool a)
        {
            Childs = new List<Element>();
            Name = name;
            Childs.Add(new TypeElement("nya", true));
            Childs.Add(new TypeElement("uhh", true));
        }

        public override string Info { get { return "namespace" + " " + Name; } }
    }
}
