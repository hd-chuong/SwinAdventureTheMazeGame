using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy9
{
    public class LookCommand: Command 
    {
        public LookCommand(): base(new string[] {"look", "examine"})
        { }
        public override string Execute(Player player, string[] text)
        {
            IHaveInventory container = null;
            string containerId = null;
            string itemId = null;
            int textLength = text.Length;

     
            //the text should have either 1, 3 or 5 words, otherwise return "I don't know how to look like that"
            if (textLength != 1 && textLength != 3 && textLength != 5)
                return "I don't know how to look like that.";
            
            //The first word must be look
            if (!AreYou(text[0]))
                return "Error in look input.";

            if (textLength == 1)
            {
                string result;
                result = String.Format("You are in {0}{1}{2}{3}There are exits to the ",
                                        player.CurrentLocation.Name, Environment.NewLine,
                                        player.CurrentLocation.FullDescription, Environment.NewLine);
                for (int i = 0; i < player.CurrentLocation.PathList.Count; ++i)
                {
                    result += player.CurrentLocation.PathList[i].Name;
                    if (i == player.CurrentLocation.PathList.Count - 1)
                        result += ".";
                    else
                        result += ", and ";
                }
                return result;
            }

            //The second word must be at
            if (text[1] != "at")
                return "What do you want to look at?";

            //The container is player if there are 3 elements
            if (textLength == 3)
                container = player as IHaveInventory;

            //If there are 5 elements, then the 4th word must be "in"
            if (textLength == 5)
            {
                if (text[3] != "in")
                    return "What do you want to look in?";
                else
                {
                    containerId = text[4];
                    container = FetchContainer(player, containerId);
                }
            }
            //The itemId is in the 3rd word
            itemId = text[2];

            if (container == null)
                return $"I cannot find the {containerId}";

            return LookAtIn(itemId, container);
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject obj = container.Locate(thingId);
            if (obj != null)
                return obj.FullDescription;
            else
                return $"I cannot find the {thingId} in the {container.Name}";
        }

        private IHaveInventory FetchContainer(Player player, string containerId)
        {
            return player.Locate(containerId) as IHaveInventory;
        }
    }
}
