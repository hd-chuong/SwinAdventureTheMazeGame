using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy9
{
    public class DropCommand: Command
    {
        public DropCommand() : base(new string[] { "drop", "put" })
        { }

        public override string Execute(Player player, string[] text)
        {
            IHaveInventory container = null;
            string containerId = null;
            string itemId = null;
            int textLength = text.Length;

            //the text should have either 2 or 4 words, otherwise return "I don't know how to look like that"
            if (textLength != 2 && textLength != 4)
                return "I don't know how to put like that.";

            //The first word must be take/pickup
            if (!AreYou(text[0]))
                return "Error in put input.";

            //The container is player current location if there are 2 elements
            if (textLength == 2)
                container = player.CurrentLocation as IHaveInventory;

            //If there are 4 elements, then the 3th word must be "in"
            if (textLength == 4) {
                if (text[2] != "in")
                    return "What do you want to put in?";
                else {
                    containerId = text[3];
                    container = FetchContainer(player, containerId);
                }
            }
            //The itemId is in the 2nd word
            itemId = text[1];

            if (container == null)
                return $"I cannot find the {containerId}";

            return PutIn(itemId, player, container);
        }

        private IHaveInventory FetchContainer(Player player, string containerId)
        {
            return player.Locate(containerId) as IHaveInventory;
        }

        private string PutIn(string thingId, Player player, IHaveInventory container)
        {
            GameObject obj = player.Locate(thingId);
            if (obj != null)
            {
                container.Inventory.Put(player.Inventory.Take(thingId) as Item);
                return $"You have put {obj.Name} in {container.Name}";
            }
            else return $"I cannot find the {thingId} from me";
        }
    }
}
