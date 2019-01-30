using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy9
{
    public class MoveCommand: Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        { }

        public override string Execute(Player player, string[] text)
        {
            Path path;
            string pathId;
            int textLength = text.Length;
            if (textLength != 2)
                return "I don't know how to move for that.";

            if (!AreYou(text[0]))
                return "Error in move input.";

            pathId = text[1];
            path = player.CurrentLocation.GetPath(pathId);
            if (path == null)
                return $"No path {pathId}";


            string stringReturned = $"You head {path.Name}" + Environment.NewLine + path.Description + Environment.NewLine;
            player.CurrentLocation = path.Destination;
            stringReturned += player.CurrentLocation.FullDescription;
            return stringReturned;
        }
    }
}
