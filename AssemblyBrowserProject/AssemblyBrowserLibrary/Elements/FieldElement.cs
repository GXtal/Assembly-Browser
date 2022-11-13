using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class FieldElement: Element
    {
        public string TypeName { get; set; }
        public FieldElement(string name, string typeName)
        {
            Childs = null;
            Name = name;
            TypeName = typeName;
        }
        public override string Info
        {
            get { return TypeName+" "+Name; }
        }
    }
}
