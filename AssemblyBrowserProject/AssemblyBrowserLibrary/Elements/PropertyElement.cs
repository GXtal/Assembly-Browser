using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class PropertyElement:Element
    {
        public string PropTypeName { get; set; }
        public string Visability { get; set; }
        public PropertyElement(PropertyInfo propertyInfo)
        {
            Childs = null;
            Visability = "";
            if(propertyInfo.GetMethod!=null)
            {
                if (propertyInfo.GetMethod.IsPublic)
                    Visability = "public";
                else if (propertyInfo.GetMethod.IsPrivate)
                    Visability = "private";
                else if (propertyInfo.GetMethod.IsAssembly)
                    Visability = "internal";
                else if (propertyInfo.GetMethod.IsFamily)
                    Visability = "protected";
                if (propertyInfo.GetMethod.IsStatic)
                    Visability += " static";
            }
            else if (propertyInfo.SetMethod!=null)
            {
                if (propertyInfo.SetMethod.IsPublic)
                    Visability = "public";
                else if (propertyInfo.SetMethod.IsPrivate)
                    Visability = "private";
                else if (propertyInfo.SetMethod.IsAssembly)
                    Visability = "internal";
                else if (propertyInfo.SetMethod.IsFamily)
                    Visability = "protected";
                if (propertyInfo.SetMethod.IsStatic)
                    Visability += " static";
            }
            
            Name =propertyInfo.Name;
            PropTypeName = TypeName(propertyInfo.PropertyType);
        }
        public override string Info
        {
            get { return "property " + Visability + " " + PropTypeName + " " + Name; }
        }
    }
}
