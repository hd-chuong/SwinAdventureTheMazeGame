using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy9
{
    interface IHaveInventory
    {
        GameObject Locate(string id);
        Inventory Inventory { get; }
        String Name { get; }
    }
}
