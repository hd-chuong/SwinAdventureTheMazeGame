using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaseStudy9
{
    public static class ExtensionMethods
    {
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }
        public static Location GetLocation(this List<Location> locations, string name)
        {
            foreach (Location location in locations)
            {
                if (location.AreYou(name))
                    return location;
            }
            return null;
        }
        public static void RegisterAllObject()
        {
            GameObject.RegisterGameObject("Item", typeof(Item));
            GameObject.RegisterGameObject("Player", typeof(Player));
            GameObject.RegisterGameObject("Location", typeof(Location));
            GameObject.RegisterGameObject("Bag", typeof(Bag));
            GameObject.RegisterGameObject("Inventory", typeof(Inventory));
            GameObject.RegisterGameObject("Path", typeof(Path));
        }
    }
}
