using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy9
{
    public class TakeCommand: Command
    {
        public TakeCommand() : base(new string[] { "take", "pickup" })
        { }

        public override string Execute(Player player, string[] text)
        {
            IHaveInventory container = null;
            string containerId = null;
            string itemId = null;
            int textLength = text.Length;

            //the text should have either 2 or 4 words, otherwise return "I don't know how to look like that"
            if (textLength != 2 && textLength != 4)
                return "I don't know how to take like that.";

            //The first word must be take/pickup
            if (!AreYou(text[0]))
                return "Error in take input.";

            //The container is player current location if there are 2 elements
            if (textLength == 2)
                container = player.CurrentLocation as IHaveInventory;

            //If there are 4 elements, then the 3th word must be "from"
            if (textLength == 4)
            {
                if (text[2] != "from")
                    return "What do you want to take from?";
                else
                {
                    containerId = text[3];
                    container = FetchContainer(player, containerId);
                }
            }
            //The itemId is in the 2nd word
            itemId = text[1];

            if (container == null)
                return $"I cannot find the {containerId}";

            return TakeFrom(itemId, player, container);
        }

        private IHaveInventory FetchContainer(Player player, string containerId)
        {
            return player.Locate(containerId) as IHaveInventory;
        }

        private string TakeFrom(string thingId, Player player, IHaveInventory container)
        {
            GameObject obj = container.Locate(thingId);
            if (obj != null)
            {
                player.Inventory.Put(container.Inventory.Take(thingId) as Item);
                return $"You have taken {obj.Name} from {container.Name}";
            }
            else
                return $"I cannot find the {thingId} in the {container.Name}";
        }
    }
}
