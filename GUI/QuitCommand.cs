using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy9
{
    public class QuitCommand: Command 
    {
        public QuitCommand(): base(new string[] {"close", "quit"})
        { }
        public override string Execute(Player player, string[] text)
        {
            return "Bye.";
        }
    }
}
