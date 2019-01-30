using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CaseStudy9
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _currentLocation;

        public Player(string name, string desc) : this(new string[] { "me", "inventory", "inv" }, name, desc)
        {
            
        }

        public Player(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            else if (Inventory.HasItem(id)) return _inventory.Fetch(id);
            else return CurrentLocation.Locate(id);

        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            Inventory.SaveTo(writer);
            writer.WriteLine(CurrentLocation.FirstID);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Inventory.LoadFrom(reader);
        }

        public void LoadCurrentLocation(StreamReader reader, List<Location> locations)
        {
            _currentLocation = locations.GetLocation(reader.ReadLine());
        }

        public override string FullDescription
        {
            get
            {
                return "You are carrying:" + Environment.NewLine + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public Location CurrentLocation
        {
            get
            {
                return _currentLocation;
            }
            set
            {
                _currentLocation = value;
            }
        }
    }
}
