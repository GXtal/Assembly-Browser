using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class FieldElement: Element
    {
        public string Visability { get; set; }

        public string FieldTypeName { get; set; }
        public FieldElement(FieldInfo fieldInfo)
        {
            Childs = null;
            Name = fieldInfo.Name;
            Visability = "";
            if (fieldInfo.IsPublic)
                Visability="public";
            else if (fieldInfo.IsPrivate)
                Visability = "private";
            else if (fieldInfo.IsAssembly)
                Visability = "internal";
            if (fieldInfo.IsFamily)
                Visability = "protected";
            if (fieldInfo.IsStatic)
                Visability+=" static";
            FieldTypeName = TypeName(fieldInfo.FieldType);
        }
        public FieldElement(string name, string typeName)
        {
            Childs = null;
            Name = name;
            FieldTypeName = typeName;
        }
        public override string Info
        {
            get { return "field "+Visability+" "+FieldTypeName+" "+Name; }
        }
    }
}
