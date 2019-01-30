using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CaseStudy9
{
    public class Path: GameObject
    {
        private Location _destination;
        public Path(string[] ids, string name, string desc) : base(ids, name, desc)
        { }

        public Location Destination { get => _destination; set { _destination = value; } }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine(Destination.FirstID);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
        }

        public void LoadDestination(StreamReader reader, List<Location> locationList)
        {
            Destination = locationList.GetLocation(reader.ReadLine());
        }
    }
}
