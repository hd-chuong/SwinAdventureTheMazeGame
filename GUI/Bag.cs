using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CaseStudy9
{
    public class Bag: Item, IHaveInventory
    {
        Inventory _inventory; 
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            if (_inventory.HasItem(id)) return _inventory.Fetch(id);
            else return null;
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            this.Inventory.SaveTo(writer);

        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            this.Inventory.LoadFrom(reader);
        }

        public override string FullDescription
        {
            get
            {
                return "In the " + Name + " you can see:" + Environment.NewLine + _inventory.ItemList;
            }
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
