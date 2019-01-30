using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaseStudy9
{
    public class GameData
    {
        private List<Location> _locationList;
        private Player _player;
        public Player Player
        {
            get
            {
                return _player;
            }
        }
        public GameData()
        {
            _locationList = new List<Location>();
        }
        public void New()
        {
            #region Create New GameData
            Location hallway = new Location(new string[] { "Hallway" }, "the Hallway", "This is a long well lit hallway.");
            Location closet = new Location(new string[] { "Closet" }, "a small Closet", "A small dark closet, with an odd smell.");
            Location garden = new Location(new string[] { "Garden" }, "a small garden", "There are many small shrubs and flowers growing from well-tended garden beds.");

            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "A old, useless shovel");
            Item sword = new Item(new string[] { "sword" }, "a sword", "A short sword cast from bronze");
            Item pc = new Item(new string[] { "pc", "computer" }, "the small computer", "The light from the monitor of this computer illuminates the room");
            Item gem = new Item(new string[] { "gem" }, "a red gem", "a bright red ruby the size of your fist!");

            Bag bag = new Bag(new string[] { "bag" }, "a leather bag", "a small brown leather bag");

            Path pathSouth = new Path(new string[] { "South", "s" }, "South", "You go through a door");
            pathSouth.Destination = closet;
            Path pathEast = new Path(new string[] { "East", "e" }, "East", "You travel through a small door, and then crawl a few meters before arriving " +
                                                                           "from the north");
            pathEast.Destination = garden;
            hallway.PathList.Add(pathSouth);
            hallway.Inventory.Put(shovel);
            hallway.Inventory.Put(sword);

            closet.PathList.Add(pathEast);
            closet.Inventory.Put(pc);

            bag.Inventory.Put(gem);
            garden.Inventory.Put(bag);

            _locationList.Add(hallway);
            _locationList.Add(closet);
            _locationList.Add(garden);
            #endregion
            #region Create New PlayerData
            _player = new Player("Fred", "the mighty programmer");
            _player.CurrentLocation = hallway;
            #endregion
        }
        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
           
            try
            {
                writer.WriteLine(_locationList.Count);
                foreach (Location location in _locationList)
                {
                    location.SaveTo(writer);
                }

                //writer.WriteLine(_pathList.Count);
                foreach(Location location in _locationList)
                {
                    writer.WriteLine(location.FirstID);
                    writer.WriteLine(location.PathList.Count);
                    foreach (Path path in location.PathList)
                    {
                        path.SaveTo(writer);
                    }
                }

                _player.SaveTo(writer);
                writer.Close();
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            GameObject gameObject;
            Location currentLocation;

            int index, index2, numberLocation, numberPath;

            _locationList.Clear();
            try
            {
                //
                //Load All Locations
                //
                numberLocation = reader.ReadInteger();
                for (index = 0; index < numberLocation; ++index)
                {
                    gameObject = (Location) GameObject.CreateGameObject(reader.ReadLine(), new string[] { }, null, null);
                    gameObject.LoadFrom(reader);
                    _locationList.Add(gameObject as Location);
                }
                //
                //Load All Paths
                //
                
                for (index = 0; index < numberLocation; ++index)
                {
                    currentLocation = _locationList.GetLocation(reader.ReadLine());
                    numberPath = reader.ReadInteger();
                    for (index2 = 0; index2 < numberPath; ++index2)
                    {
                        gameObject = GameObject.CreateGameObject(reader.ReadLine(), new string[] { }, null, null);

                        gameObject.LoadFrom(reader);

                        (gameObject as Path).LoadDestination(reader, _locationList);

                        currentLocation.PathList.Add(gameObject as Path);
                    }
                }
                //Load Player
                gameObject = GameObject.CreateGameObject(reader.ReadLine(), new string[] { }, null, null);
                gameObject.LoadFrom(reader);
                _player = gameObject as Player;
                _player.LoadCurrentLocation(reader, _locationList);

                reader.Close();
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
