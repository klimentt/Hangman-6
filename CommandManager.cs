namespace HangmanSix
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Keeps all possible commands given from player
    /// </summary>
    public class CommandManager : IRemovable, IAddable
    {
        private List<string> allCommands = new List<string>();

        public List<string> AllComands
        {
            get { return this.allCommands; }
        }

        public void LoadAllCommands()
        { 
            //read from file and add to allCommands
        }

        public void Add(string newCommand)
        {
            //write to file and add to allCommands
        }

        public void Remove(int index)
        {
            //delete from file and from allComands
        }
    }
}
