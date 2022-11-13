namespace AssemblyBrowserLibrary.Elements
{
    public class Element
    {
        public string Name { get; set; }
        public List<Element> Childs { get; set; }

        public virtual string Info
        {
            get { return "a"; }
        }

    }
}