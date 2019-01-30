using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy9
{
    public abstract class Command: Identifiable
    {
        public Command(string[] ids) : base(ids)
        { }
        public abstract string Execute(Player player, string[] text);
    }
}
