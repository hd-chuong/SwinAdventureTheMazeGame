using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CaseStudy9
{
    public class Item: GameObject
    {
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        { }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
        }
    }
}
