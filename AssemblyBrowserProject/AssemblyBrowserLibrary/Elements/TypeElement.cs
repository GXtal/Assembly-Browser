using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class TypeElement : Element
    {
        public TypeElement()
        {
            Childs = new List<Element>();
            Name = "nyanyanaynaynaynay";
        }
        public TypeElement(string name, bool a)
        {
            Childs = new List<Element>();
            Name = name;
            Childs.Add(new FieldElement("nyasaasas","int"));
            Childs.Add(new FieldElement("uhasasah", "string"));
        }

        public override string Info
        {
            get { return Name; }
        }
    }
}
