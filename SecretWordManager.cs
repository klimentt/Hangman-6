namespace HangmanSix
{
    using System;
    using System.IO;
using System.Collections.Generic;

    /// <summary>
    /// Keeps all possible secret words
    /// </summary>
    public class SecretWordManager : IExpandable, IRemovable
    {
        private List<string> allSecretWords=new List<string>();

        public List<string> AllSecretWords
        {
            get { return this.allSecretWords; }
        }

        public void LoadAllSecretWords(string path) 
        {
            string[] words = File.ReadAllLines(path
);

            foreach (string line in words)
            {
                allSecretWords.AddRange(line.Split(','));
            }
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
