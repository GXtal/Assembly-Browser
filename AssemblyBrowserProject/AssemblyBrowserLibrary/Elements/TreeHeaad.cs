using System;
using System.Collections.Generic;
using System.Linq;
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
            foreach(var space in allTypes.Keys)
            {
                Childs.Add(new NameSpaceElement(space, allTypes[space]));
            }
        }
        public TreeHeaad(bool a)
        {
            Childs = new List<Element>();
            Name = "nyanyanaynaynaynay";
            Childs.Add(new NameSpaceElement("uhuhu",true));
            Childs.Add(new NameSpaceElement("uhusaudhau", true));
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
