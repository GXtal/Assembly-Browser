using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class MethodElement:Element
    {
        public string ReturnTypeName { get; set; }

        public string Visability { get; set; }
        public string[] Parametrs { get; set; }
        public MethodElement(MethodInfo methodInfo)
        {
            Childs = null;
            Name = methodInfo.Name;
            Visability = "";
            if (methodInfo.IsPublic)
                Visability = "public";
            else if (methodInfo.IsPrivate)
                Visability = "private";
            else if (methodInfo.IsAssembly)
                Visability = "internal";
            if (methodInfo.IsFamily)
                Visability = "protected";
            if (methodInfo.IsStatic)
                Visability += " static";
            ReturnTypeName = TypeName(methodInfo.ReturnType);
            var parametrs=methodInfo.GetParameters();
            Parametrs = new string[parametrs.Length];
            for (int i = 0; i < parametrs.Length; i++)
            {
                if (parametrs[i].IsOut)
                {
                    Parametrs[i] = "out ";
                }
                else if(parametrs[i].ParameterType.IsByRef)
                {
                    Parametrs[i] = "ref ";
                }
                else Parametrs[i] = "";
                Parametrs[i] += TypeName(parametrs[i].ParameterType);
                Parametrs[i] += " " +parametrs[i].Name;
            }
        }

        public override string Info
        {
            get {
                string allParams = "";
                foreach (var param in Parametrs)
                {
                    allParams += param;
                    allParams += ",";
                }
                if(allParams.Length > 0)
                {
                    allParams = allParams.Remove(allParams.Length - 1);
                }
                
                
                return "method " + Visability + " " + ReturnTypeName + " " + Name +"("+allParams+")"; }
        }

    }
}
