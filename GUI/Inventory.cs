using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CaseStudy9
{
    public class Inventory
    {
        List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }   
        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                    return true;
            }
            return false;
        }

        public void Put(Item item)
        {
            if (item != null)
                _items.Add(item);
        }

        public Item Take(string id)
        {
            Item result = Fetch(id);
            _items.Remove(result);
            return result;
        }

        public Item Fetch(string id)
        {
            Item result;
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    result = item;
                    return result;
                }
            }
            return null;
        }

        public void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(_items.Count);
            foreach (Item item in _items)
            {
                item.SaveTo(writer);
            }
        }

        public void LoadFrom(StreamReader reader)
        {
            int numberItem, index;
            _items.Clear();
            GameObject gameObject;

            numberItem = reader.ReadInteger();
            for (index = 0; index < numberItem; ++index)
            {
                gameObject = GameObject.CreateGameObject(reader.ReadLine(), new string[] { }, null, null);
                gameObject.LoadFrom(reader);
                Put(gameObject as Item);
            }
        }

        public string ItemList
        {
            get
            {
                string result = "";
                foreach (Item item in _items)
                {
                    result += "\t" + item.ShortDescription + Environment.NewLine;
                }
                return result;
            }
        }
    }
}
