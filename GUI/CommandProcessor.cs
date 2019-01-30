using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy9
{
    public class CommandProcessor
    {
        private List<Command> _commandList;
        public List<Command> CommandList
        {
            get
            {
                return _commandList;
            }
        }

        public CommandProcessor()
        {
            _commandList = new List<Command>();

            _commandList.Add(new LookCommand());
            _commandList.Add(new MoveCommand());
            _commandList.Add(new TakeCommand());
            _commandList.Add(new DropCommand());
            _commandList.Add(new QuitCommand());
        }

        public string Execute(Player player, string sentence)
        {
            string[] words = sentence.Split(' ');

            if (words.Length < 1) return "Why do you stay silent?";

            foreach (Command command in CommandList)
            {
                if (command.AreYou(words[0]))
                    return command.Execute(player, words);
            }
            return "I don't know what you mean.";
        }
    }
}
