using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace CaseStudy9
{
    public abstract class Identifiable
    {
        private List<string> _ids = new List<string>();
        
        public Identifiable(string[] ids)
        {
            foreach(string s in ids)
            {
                AddIdentifier(s);
            }
        }

        public bool AreYou(string id)
        {
            foreach (string s in _ids)
            {
                if (s == id.ToLower())
                {
                    return true;
                }
            }
            return false;

        }
        public void AddIdentifier(string id)
        {
            _ids.Add(id.ToLower());
        }

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(_ids.Count);
            foreach(string s in _ids)
            {
                writer.WriteLine(s);
            }
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            int index, numberId;

            this._ids.Clear();

            numberId = reader.ReadInteger();
            for (index = 0; index < numberId; ++index)
            {
                this.AddIdentifier(reader.ReadLine());
            }
        }

        public string FirstID
        {
            get
            {
                return (_ids.Count > 0) ? _ids[0] : "";
            }
        }
    }
}
