namespace HangmanSix
{
    using System;
using System.Collections.Generic;

    /// <summary>
    /// Keeps all possible secret words
    /// </summary>
    public class SecretWordManager : IAddable, IRemovable
    {
        private List<string> allSecretWords=new List<string>();

        public List<string> AllSecretWords
        {
            get { return this.allSecretWords; }
        }

        public void LoadAllSecretWords() 
        {
            //read from file and add to allSecretWords;
        }
        
        public void Remove(int index)
        {
            allSecretWords.RemoveAt(index);
        }

        public void Add(string newSecretWord)
        {
            allSecretWords.Add(newSecretWord);
        }
    }
}
