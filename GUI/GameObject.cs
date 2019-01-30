using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CaseStudy9
{
    public abstract class GameObject : Identifiable
    {
        private static Dictionary<string, Type> _GameObjectClassRegistry = new Dictionary<string, Type>();

        private string _description;
        private string _name;

        public GameObject(string[] ids, string name, string desc): base(ids)
        { 
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
        }

        public string ShortDescription
        {
            get
            {
                return _name + " ("+ FirstID + ")";
            }
        }
        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }

        public string GetType(Type t)
        {
            foreach(var connection in _GameObjectClassRegistry)
            {
                if (connection.Value == t) return connection.Key;
            }
            return null;
        }

        public static GameObject CreateGameObject(string type, string[] ids, string name, string desc)
        {
            Object[] args = { ids, name, desc };
            return (GameObject) Activator.CreateInstance(_GameObjectClassRegistry[type], args);
        }

        public static void RegisterGameObject(string name, Type t)
        {
            _GameObjectClassRegistry[name] = t;
        }
 
        #region SaveTo and LoadFrom
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(GetType( this.GetType() ));
            base.SaveTo(writer);
            writer.WriteLine(Name);
            writer.WriteLine(Description);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            this._name = reader.ReadLine();
            this._description = reader.ReadLine();
        }
        
        #endregion
    }
}
