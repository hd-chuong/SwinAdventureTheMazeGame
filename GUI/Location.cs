using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CaseStudy9
{
    public class Location: GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _pathList;

        public Inventory Inventory { get => _inventory; }
        public List<Path> PathList { get => _pathList; }
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _pathList = new List<Path>();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            else return Inventory.Fetch(id);
        }
        
        public void Put(Player player)
        {
            player.CurrentLocation = this;
        }

        public void Put(Item item)
        {
            _inventory.Put(item);
        }

        public void Put(Path path)
        {
            _pathList.Add(path);
        }

        public bool HasPath(string id)
        {
            foreach (Path path in PathList)
                if (path.AreYou(id)) return true;
            return false;
        }

        public Path GetPath(string id)
        {
            foreach (Path path in PathList)
                if (path.AreYou(id)) return path;
            return null;
        }
        
        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            this.Inventory.SaveTo(writer);
        }
        //
        //this method only saves and loads identifiable information and items in each location
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            this.Inventory.LoadFrom(reader);
        }

        public override string FullDescription
        {
            get
            {
                return String.Format("In the {0} you can see:{1}", Name, Environment.NewLine) + Inventory.ItemList;
            }
        }
    }
}
