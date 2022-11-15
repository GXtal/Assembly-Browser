using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class NameSpaceElement:Element
    {
        public NameSpaceElement(string name, List<Type> types, ref List<MethodInfo> exts)
        {
            Name = name;
            Childs = new List<Element>();
            foreach(var type in types)
            {
                if(!type.IsDefined(typeof(CompilerGeneratedAttribute),false))
                {
                    List<MethodInfo> tempe;
                    var temp = new TypeElement(type,ref exts);
                    
                    if(temp!=null)
                    {
                        Childs.Add(temp);
                    }
                    
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

        public override void AddExt(string baseType, MethodInfo method)
        {
            bool result = false;
            foreach(var type in Childs)
            {
                if(type.Name == baseType)
                {
                    type.AddExt(baseType, method);
                    result = true;
                    break;
                }
            }
            if(!result)
            {

            }
        }
        public override string Info { get { return "namespace" + " " + Name; } }
    }
}
