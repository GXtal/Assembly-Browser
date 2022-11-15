using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary.Elements
{
    public class TreeHeaad:Element
    {
        public TreeHeaad(Dictionary<string, List<Type>> allTypes)
        {
            Childs = new List<Element>();
            Name = "ok";
            var exts = new List<MethodInfo>();
            foreach(var space in allTypes.Keys)
            {
                var temp = new NameSpaceElement(space, allTypes[space],ref exts);
                if(temp.Childs.Count > 0)
                {
                    Childs.Add(temp);
                }
                
            }
            foreach(var method in exts)
            {
                AddExts(method);
            }
        }
        public TreeHeaad(bool a)
        {
            Childs = new List<Element>();
            Name = "nyanyanaynaynaynay";
            Childs.Add(new NameSpaceElement("uhuhu",true));
            Childs.Add(new NameSpaceElement("uhusaudhau", true));
        }
        private void AddExts(MethodInfo ext)
        {
            bool result = false;
            var a =MethodInfoExtensions.GetBaseDefinition(ext);
            var baseType = ext.GetParameters()[0].ParameterType;
            foreach(var space in Childs)
            {
                if(space.Name==baseType.Namespace)
                {
                    space.AddExt(baseType.Name, ext);
                    result = true;
                    break;
                }
            }
            if(!result)
            {
                
            }
        }

        public TreeHeaad(string message)
        {
            Name = message;
            Childs = null;
        }
        public virtual string Info
        {
            get { return "treehead"; }
        }

    }
}
