using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class TypeElement : Element
    {
        public string Additions;
        public TypeElement(Type type, ref List<MethodInfo> exts)
        {
            Name=type.Name;
            Additions = "";
            if (type.IsAbstract)
                Additions+="abstract ";
            else if (type.IsSealed)
                Additions+="sealed ";
            
            Childs = new List<Element>();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance|BindingFlags.Static);
            foreach(FieldInfo fieldInfo in fields)
            {
                if(!fieldInfo.IsDefined(typeof(CompilerGeneratedAttribute)))
                {
                    Childs.Add(new FieldElement(fieldInfo));
                }
                
            }
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance| BindingFlags.Static);
            foreach(PropertyInfo propertyInfo in properties)
            {
                Childs.Add(new PropertyElement(propertyInfo));
            }
            
            
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance|BindingFlags.Static);
            foreach (MethodInfo methodInfo in methods)
            {
                if(methodInfo.IsDefined(typeof(ExtensionAttribute)))
                {
                    exts.Add(methodInfo);
                }
                else
                if(!methodInfo.IsDefined(typeof(CompilerGeneratedAttribute)))
                {
                    Childs.Add(new MethodElement(methodInfo));
                }
                
            }
        }
        public TypeElement(string name, bool a)
        {
            Childs = new List<Element>();
            Additions = "";
            Name = name;
            Childs.Add(new FieldElement("nyasaasas","int"));
            Childs.Add(new FieldElement("uhasasah", "string"));
        }

        public override void AddExt(string baseType, MethodInfo method)
        {
            Childs.Add(new MethodElement(method,true));
        }
        public override string Info
        {
            get { return Additions+Name; }
        }
    }
}
